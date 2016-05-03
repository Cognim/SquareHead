(function () {
	"use strict";

	angular.module("gameGrid")
		.directive("squareHead", function () {
			return {
				restrict: "E",
				replace: true,
				scope: {
					gridViewModel: "="
				},
				templateUrl: "App/Components/SquareHead/squareHead.html"
			};
		});
}());