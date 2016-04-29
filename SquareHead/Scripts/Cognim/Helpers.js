(function (Cognim) {
	"use strict";

	Cognim.Helpers = Cognim.Helpers || {

		chunkArray: function (array, size) {
			var chunkedArray = [];

			for (var i = 0, len = array.length; i < len; i += size) {
				chunkedArray.push(array.slice(i, i + size));
			}
			return chunkedArray;
		},

	};

}(window.Cognim = window.Cognim || {}));