angular.module('gameGrid', []);

(function () {
	"use strict";

	var sequencedGridController = function ($http, $timeout) {

		var gameModel = this;
		gameModel.gameInProgress = false;
		gameModel.size = "rows=5&columns=2";
		gameModel.type = "random";
		gameModel.elapsedTime = 0;

		gameModel.onCellClicked = function (cell) {
			if (cell.completed) return;
			
			if (cell == gameModel.expectedCell || !gameModel.expectedCell) {
				cell.completed = true;
				gameModel.gameInProgress = true;
				gameModel.expectedCell = getExpectedCellFromCurrent(cell);
			}

			if(allCellsComplete()) {
				gameModel.gameInProgress = false;
			}
		}

		gameModel.onSizeClicked = function(size) {
			gameModel.size = size;
			renderGrid();
		}

		gameModel.onTypeClicked = function(type) {
			gameModel.type = type;
			renderGrid();
		}

		var getExpectedCellFromCurrent = function(currentCell) {
			var nextCell = getCellById(currentCell.NextCellId);
			if (!nextCell || nextCell.completed)
				return null;
			return nextCell;
		}

		var allCellsComplete = function() {
			for (var index = 0; index < gameModel.grid.Cells.length; index++) {
				if (!gameModel.grid.Cells[index].completed) {
					return false;
				}
			}
			return true;
		}

		var getCellById = function (id) {
			for (var index = 0; index < gameModel.grid.Cells.length; index++) {
				if (gameModel.grid.Cells[index].Id === id) {
					return gameModel.grid.Cells[index];
				}
			}
			return null;
		}

		var initialiseGrid = function() {
			for (var index = 0; index < gameModel.grid.Cells.length; index++) {
				gameModel.grid.Cells[index].completed = false;
			}
			gameModel.grid.rows = Cognim.Helpers.chunkArray(gameModel.grid.Cells, gameModel.grid.NumberOfColumns);
			gameModel.gameInProgress = false;
			gameModel.elapsedTime = 0;
			gameModel.expectedCell = getCellById(gameModel.grid.FirstCellId);
		}

		var onGotGrid = function (response) {
			gameModel.grid = response.data;
			initialiseGrid();
		}

		var renderGrid = function(){
			$http.get("/api/grid/" + gameModel.type + "?" + gameModel.size).then(onGotGrid);
		}
	};

	angular.module('gameGrid')
		.controller('sequencedGridController', sequencedGridController)
		.directive('cgTimer', function ($timeout) {
			return {
				restrict: 'E',
				scope: {
					millisecondsSinceStart: '=',
					runTimer: '='
				},
				template: "{{millisecondsSinceStart | date:'mm:ss:sss'}}",

				link: function (scope) {

					scope.updateElapsedTime = function () {
						if (scope.runTimer) {
							scope.millisecondsSinceStart = new Date().getTime() - scope.startTime;
							$timeout(scope.updateElapsedTime, 10);
						}
					}

					scope.$watch('runTimer', function (runTimer) {
						if (runTimer) {
							scope.startTime = new Date().getTime();
							$timeout(scope.updateElapsedTime, 10);
						}
					});
				},


			}
		});;
}());