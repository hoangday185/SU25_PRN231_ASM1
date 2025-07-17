$(function () {
	// 1. Lấy id từ URL
	function getIdFromUrl() {
		var path = window.location.pathname;
		var parts = path.split("/");
		return parts[parts.length - 1];
	}
	var id = getIdFromUrl();

	// 2. Gọi API GET để lấy chi tiết
	$.ajax({
		url: "https://localhost:7280/api/QuitMethodHoangnv/" + id,
		type: "GET",
		success: function (data) {
			var html = `
                <dl>
                    <dt>Method Name</dt><dd>${data.methodName}</dd>
                    <dt>Description</dt><dd>${data.methodDescription}</dd>
                    <dt>Effectiveness Rating</dt><dd>${
											data.effectivenessRating
										}</dd>
                    <dt>Difficulty Level</dt><dd>${data.difficultyLevel}</dd>
                    <dt>Recommended Duration</dt><dd>${
											data.recommendedDuration
										}</dd>
                    <dt>Requires Medical</dt><dd>${data.requiresMedical}</dd>
                    <dt>Requires Counseling</dt><dd>${
											data.requiresCounseling
										}</dd>
                    <dt>Is Popular</dt><dd>${data.isPopular}</dd>
                    <dt>CreationDateTime</dt><dd>${
											data.creationDateTime
												? data.creationDateTime.substring(0, 19)
												: ""
										}</dd>
                    <dt>Is Active</dt><dd>${data.isActive}</dd>
                </dl>
            `;
			$("#method-detail").html(html);
			data.isActive == "false" && $("#btn-delete").hide();
		},
		error: function (xhr) {
			$("#method-detail").html(
				'<span class="text-danger">Không tìm thấy dữ liệu!</span>'
			);
			$("#btn-delete").hide();
		},
	});

	// 3. Gọi API DELETE khi bấm nút Delete
	$("#btn-delete").on("click", function () {
		if (confirm("Bạn chắc chắn muốn xóa phương pháp này?")) {
			$.ajax({
				url: "https://localhost:7280/api/QuitMethodHoangnv/" + id,
				type: "DELETE",
				success: function () {
					$("#result-message").html(
						'<span class="text-success">Đã xóa thành công!</span>'
					);
					$("#btn-delete").hide();
					setTimeout(() => {
						$("#result-message").html("");
					}, 2000);
				},
				error: function (xhr) {
					$("#result-message").html(
						'<span class="text-danger">Xóa thất bại: ' +
							xhr.responseText +
							"</span>"
					);
				},
			});
		}
	});
});
