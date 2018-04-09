$(document).ready(function () {
    $("#btnSearch").kendoButton({
        click: onSearch
    });

    dataSource = new kendo.data.DataSource({
        transport: {
            create: {
                url: "/Exercise/Exercise_Create", 
                type: "post", 
                complete: function (e) {
                    $("#grid").data("kendoGrid").dataSource.read();
                }
            },
            read: {
                url: "/Exercise/Exercises_Read", 
                dataType: "json",
                type: "get" 
            },
            parameterMap: function (data, operation) {
                if (operation === "create") {
                    data.ExerciseDate = kendo.toString(data.ExerciseDate, "MMM/dd/yyyy");
                }
                return data;
            }
        },
        pageSize: 10,
        error: function (e) {
            alert("This record cannot be added");
        },
        schema: {
            model: { 
                id: "Id",
                fields: {
                    Id: { type: "number", nullable: true, editable: false },

                    ExerciseName: {
                        type: "string", validation: {
                            required: true,
                            maxlength:
                            function (input) {
                                if (input.val().length > 100 && input.is("[name='ExerciseName']")) {
                                    input.attr("data-maxlength-msg", "Max length is 100");
                                    return false;
                                }
                                return true;
                            }
                        }
                    },

                    ExerciseDate: { type: "date", required: true },
                    DurationTime: {
                        type: "number", validation: {
                            required: true, valuerange:
                            function (input) {
                                if ((input.val() > 120 || input.val() < 1) && input.is("[name='DurationTime']")) {
                                    input.attr("data-valuerange-msg", "Max value is 120 and min value is 1");
                                    return false;
                                }
                                return true;
                            }
                        }
                    }
                }
            }
        }
    });
    $("#grid").kendoGrid({
        dataSource: dataSource,
        pageable: true,
        height: 550,
        toolbar: ["create"],
        columns: [
            { field: "ExerciseName", title: "Exercise Name", format: "{0:c}", width: "140px", filterable: true },
            {
                field: "ExerciseDate", title: "Exercise Date", template: '#= kendo.toString(ExerciseDate,"MMM/dd/yyyy") #', filterable: false
            },
            { field: "DurationTime", title: "Duration Time in minutes", width: "180px", filterable: false }],
        editable: "popup",
        sortable: true
    });
});

function error_handler(e) {
    window.console.log("ejoelje");
    if (e.errors) {
        var message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        alert(message);
    }
}
function onSearch() {
    var q = $("#SearchString").val();
    var grid = $("#grid").data("kendoGrid");
    grid.dataSource.query({
        page: 1,
        pageSize: 10,
        filter: {
            filters: [
                { field: "ExerciseName", operator: "contains", value: q }
            ]
        }
    });
}
