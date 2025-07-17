$(function () {
	// 1. Lấy id từ URL (giả sử url dạng /QuitMethodHoangnv/Edit/5)
	function getIdFromUrl() {
		var path = window.location.pathname;
		var parts = path.split("/");
		return parts[parts.length - 1];
	}
	var id = getIdFromUrl();

	// 2. Gọi API GET để lấy dữ liệu và đổ lên form
	$.ajax({
		url: "https://localhost:7280/api/QuitMethodHoangnv/" + id,
		type: "GET",
		success: function (data) {
			$("#QuitMethodHoangNvid").val(data.quitMethodHoangNvid);
			$("#MethodName").val(data.methodName);
			$("#MethodDescription").val(data.methodDescription);
			$("#EffectivenessRating").val(data.effectivenessRating);
			$("#DifficultyLevel").val(data.difficultyLevel);
			$("#RecommendedDuration").val(data.recommendedDuration);
			$("#RequiresMedical").val(data.requiresMedical);
			$("#RequiresCounseling").val(data.requiresCounseling);
			$("#IsPopular").val(data.isPopular);
			$("#CreationDateTime").val(
				data.creationDateTime ? data.creationDateTime.substring(0, 19) : ""
			);
			$("#IsActive").val(data.isActive);
		},
		error: function (xhr) {
			$("#result-message").html(
				'<span class="text-danger">Không tìm thấy dữ liệu!</span>'
			);
		},
	});

	// 3. Gọi API PUT để cập nhật khi submit form
	$("form").on("submit", function (e) {
		e.preventDefault();
		var data = {
			quitMethodHoangNvid: $("#QuitMethodHoangNvid").val(),
			methodName: $("#MethodName").val(),
			methodDescription: $("#MethodDescription").val(),
			effectivenessRating: $("#EffectivenessRating").val(),
			difficultyLevel: $("#DifficultyLevel").val(),
			recommendedDuration: $("#RecommendedDuration").val(),
			// ... các trường khác nếu có
		};
		$.ajax({
			url: "https://localhost:7280/api/QuitMethodHoangnv/" + id,
			type: "PUT",
			contentType: "application/json",
			data: JSON.stringify(data),
			success: function (res) {
				$("#result-message").html(
					'<span class="text-success">Cập nhật thành công!</span>'
				);
				setTimeout(() => {
					$("#result-message").html("");
				}, 2000);
			},
			error: function (xhr) {
				$("#result-message").html(
					'<span class="text-danger">Cập nhật thất bại: ' +
						xhr.responseText +
						"</span>"
				);
			},
		});
	});
});
