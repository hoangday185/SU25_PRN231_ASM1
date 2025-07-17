const loadListData = () => {
	$.ajax({
		url: "https://localhost:7280/api/QuitMethodHoangnv",
		type: "GET",
		success: function (data) {
			let html = "";
			data.items.forEach((item) => {
				html += `<tr>
                        <td>${item.methodName}</td>
                        <td>${item.methodDescription}</td>
                        <td>${item.effectivenessRating ?? " "}</td>
                        <td>${item.difficultyLevel ?? " "}</td>
                        <td>${item.recommendedDuration ?? " "}</td>
                        <td>${item.isActive ? "Yes" : "No"}</td>
                        <td>
                            <a href="/QuitMethodHoangnv/Edit/${
															item.quitMethodHoangNvid
														}">Edit</a> |
                            <a href="/QuitMethodHoangnv/Details/${
															item.quitMethodHoangNvid
														}">Details</a>`;
				// Chỉ hiển thị nút Delete nếu isActive == true
				if (item.isActive || item.isActive == "true") {
					html += ` | <a href="/QuitMethodHoangnv/Delete/${item.quitMethodHoangNvid}">Delete</a>`;
				}
				html += `</td>
                    </tr>`;
			});
			$("#method-table tbody").html(html);
		},
		error: function (xhr) {
			$("#method-table tbody").html(
				'<tr><td colspan="7" class="text-danger">Không thể tải dữ liệu!</td></tr>'
			);
		},
	});
};

window.addEventListener("pageshow", (e) => {
	if (
		e.persisted ||
		(window.performance && window.performance.navigation.type === 2)
	) {
		loadListData();
	}
});

$(document).ready(function () {
	loadListData();
});
