// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function () {
    var timer;

    function getConfig() {
        return window.doctorConfig || {};
    }

    function renderDoctors(doctors) {
        var $tbody = $("#doctorsTable");
        $tbody.empty();

        var config = getConfig();
        var editUrl = config.editUrl || "/Doctor/Edit";
        var detailsUrl = config.detailsUrl || "/Doctor/Details";
        var deleteUrl = config.deleteUrl || "/Doctor/Delete";

        $.each(doctors, function (_, doctor) {
            var firstName = doctor.FirstName ?? doctor.firstName;
            var lastName = doctor.LastName ?? doctor.lastName;
            var specialty = doctor.Specialty ?? doctor.specialty;
            var hospitalName = doctor.HospitalName ?? doctor.hospitalName;
            var id = doctor.Id ?? doctor.id;

            var $row = $("<tr></tr>");
            $row.append("<td>" + firstName + "</td>");
            $row.append("<td>" + lastName + "</td>");
            $row.append("<td>" + specialty + "</td>");
            $row.append("<td>" + hospitalName + "</td>");
            $row.append(
                "<td>" +
                "<a class='btn btn-sm btn-primary me-1' href='" + editUrl + "?id=" + id + "'>Edit</a> " +
                "<a class='btn btn-sm btn-info me-1' href='" + detailsUrl + "?id=" + id + "'>Details</a> " +
                "<a class='btn btn-sm btn-danger' href='" + deleteUrl + "?id=" + id + "'>Delete</a>" +
                "</td>"
            );
            $tbody.append($row);
        });
    }

    function loadDoctors() {
        var config = getConfig();
        $.getJSON(config.filterUrl || "/Doctor/GetFilteredDoctors", {
            search: $("#search").val(),
            specialty: $("#specialty").val(),
            sortOrder: $("#sortOrder").val()
        }, renderDoctors);
    }

    function initDoctorFiltering() {
        $("#search, #specialty").on("input", function () {
            clearTimeout(timer);
            timer = setTimeout(loadDoctors, 300);
        });

        $("#sortOrder").on("change", loadDoctors);

        $("#clearFilters").on("click", function () {
            $("#search").val("");
            $("#specialty").val("");
            $("#sortOrder").val("name_asc");
            loadDoctors();
        });
    }

    $(document).ready(function () {
        initDoctorFiltering();
    });
})();
