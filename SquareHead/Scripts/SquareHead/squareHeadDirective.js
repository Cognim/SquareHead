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
				templateUrl: "Scripts/SquareHead/squareHead.html"
			};
		});
}());