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
				templateUrl: "App/Components/Grid/gridTemplate.html"
			};
		});
}());