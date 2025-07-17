$(function () {
	$("#form-create").on("submit", (e) => {
		e.preventDefault();
		const data = {
			methodName: $("#MethodName").val(),
			methodDescription: $("#MethodDescription").val(),
			effectivenessRating: $("#EffectivenessRating").val(),
			difficultyLevel: $("#DifficultyLevel").val(),
			recommendedDuration: $("#RecommendedDuration").val(),
		};

		$.ajax({
			url: "https://localhost:7280/api/QuitMethodHoangnv",
			type: "POST",
			contentType: "application/json",
			data: JSON.stringify(data),
			success: function () {
				$("#result-message").html(
					`<span class="text-success">Tạo thành công!</span>`
				);

				$("form")[0].reset();

				setTimeout(() => {
					$("#result-message").html("");
				}, 3000);
			},
			error: function (xhr) {
				$("#result-message").html(
					'<span class="text-danger">Tạo thất bại: ' +
						xhr.responseText +
						"</span>"
				);
			},
		});
	});
});
