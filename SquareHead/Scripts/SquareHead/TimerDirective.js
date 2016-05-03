(function() {
	"use strict";

	angular.module("gameGrid")
		.directive("cgTimer", function($timeout) {
			return {
				restrict: "E",
				replace: true,
				scope: {
					millisecondsSinceStart: "=",
					runTimer: "="
				},
				template: "<span>{{millisecondsSinceStart | date:'mm:ss:sss'}}</span>",

				link: function(scope) {

					scope.updateElapsedTime = function() {
						if (scope.runTimer) {
							scope.millisecondsSinceStart = new Date().getTime() - scope.startTime;
							$timeout(scope.updateElapsedTime, 10);
						}
					};
					scope.$watch("runTimer", function(runTimer) {
						if (runTimer) {
							scope.startTime = new Date().getTime();
							$timeout(scope.updateElapsedTime, 10);
						}
					});
				}
			};
		});
}());