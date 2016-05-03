(function() {
	"use strict";

	angular.module("gameGrid")
		.directive("settings", function() {
			return {
				restrict: "E",
				replace: true,
				scope: {
					gridViewModel: "="
				},
				templateUrl: "App/Components/Settings/settingsTemplate.html"
			};
		});
}());