(function () {
	"use strict";

	angular.module("gameGrid")
		.directive("grid", function () {
			return {
				restrict: "E",
				replace: true,
				scope: {
					gridViewModel: "="
				},
				templateUrl: "Scripts/SquareHead/gridTemplate.html"
			};
		});
}());