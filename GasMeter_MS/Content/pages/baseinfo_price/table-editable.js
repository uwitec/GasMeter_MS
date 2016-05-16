var TableEditable = function () {

    var handleTable = function () {

        function restoreRow(oTable, nRow) {
            var aData = oTable.fnGetData(nRow);
            var jqTds = $('>td', nRow);

            for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                oTable.fnUpdate(aData[i], nRow, i, false);
            }

            oTable.fnDraw();
        }

        function editRow(oTable, nRow) {
            var aData = oTable.fnGetData(nRow);
            var jqTds = $('>td', nRow);
            jqTds[0].innerHTML = '<input type="text" disabled class="form-control input-small" name="Id" value="' + aData[0] + '">';
            jqTds[1].innerHTML = '<input type="text" class="form-control input-small" name="PName" value="' + aData[1] + '">';
            jqTds[2].innerHTML = '<input type="text" class="form-control input-small" name="SinPrice" value="' + aData[2] + '">';
            jqTds[3].innerHTML = '<input type="text" class="form-control input-small" name="Describe" value="' + aData[3] + '">';
            jqTds[4].innerHTML = '<input type="text" disabled class="form-control input-small" name="StartDateTime" value="' + (aData[4] || new Date().Format("yyyy/MM/dd hh:mm:ss")) + '">';
            jqTds[5].innerHTML = '<input type="text" disabled class="form-control input-small" name="UpdateDateTime"  value="' + (aData[5] || new Date().Format("yyyy/MM/dd hh:mm:ss")) + '">';
            jqTds[6].innerHTML = '<input type="text" class="form-control input-small" name="Memo" value="' + aData[6] + '">';
            jqTds[7].innerHTML = '<a class="edit" href="">保存</a>';
            jqTds[8].innerHTML = '<a class="cancel" href="">取消</a>';
        }

        function saveRow(oTable, nRow) {
            var jqInputs = $('input[name].form-control', nRow);
            oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
            oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
            oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
            oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
            oTable.fnUpdate(jqInputs[4].value, nRow, 4, false);
            oTable.fnUpdate(new Date().Format("yyyy/MM/dd hh:mm:ss"), nRow, 5, false);
            oTable.fnUpdate(jqInputs[6].value, nRow, 6, false);
            oTable.fnUpdate('<a href="javascript:;" class="btn default btn-xs purple edit"><i class="fa fa-edit"></i> 编辑</a>', nRow, 7, false);
            oTable.fnUpdate('<a href="javascript:;" class="btn default btn-xs purple delete"><i class="icon icon-trash"></i> 删除</a>', nRow, 8, false);
            oTable.fnDraw();
        }

        function cancelEditRow(oTable, nRow) {
            var jqInputs = $('input', nRow);
            oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
            oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
            oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
            oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
            oTable.fnUpdate(jqInputs[4].value, nRow, 4, false);
            oTable.fnUpdate(jqInputs[5].value, nRow, 5, false);
            oTable.fnUpdate(jqInputs[6].value, nRow, 6, false);
            oTable.fnUpdate('<a class="edit" href="">编辑</a>', nRow, 7, false);
            oTable.fnDraw();
        }

        var table = $('#sample_editable_1');

        var oTable = table.dataTable({

            // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
            // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
            // So when dropdowns used the scrollable div should be removed. 
            //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

            "lengthMenu": [
                [5, 15, 20, 100, 500, 1000, -1],
                [5, 15, 20, 100, 500, 1000, "全部"] // change per page values here
            ],
            // set the initial value
            "pageLength": 10,

            "language": {
                "lengthMenu": " _MENU_ records",
                "sInfo": "显示第_START_条到第_END_条 共计 _TOTAL_ 条",
                "sInfoEmpty": "没有数据",
                "sEmptyTable": "暂无记录",
                "oPaginate": {
                    "sFirst": "第一页",
                    "sLast": "上一页",
                    "sNext": "下一页",
                },
                "sLengthMenu": "显示  _MENU_ 条记录",
                "sLoadingRecords": "加载中...",
                "sProcessing": "进程繁忙...",
                "sSearch": "搜索:",
                "sSearchPlaceholder": "",
                "sZeroRecords": "没有与搜索相匹配结果"
            },
            "columnDefs": [{ // set default column settings
                'orderable': true,
                'targets': [0]
            }, {
                "searchable": true,
                "targets": [0]
            }],
            "order": [
                [0, "asc"]
            ] // set first column as a default sort by asc
        });

        var tableWrapper = $("#sample_editable_1_wrapper");

        tableWrapper.find(".dataTables_length select").select2({
            showSearchInput: false //hide search box with special css class
        }); // initialize select2 dropdown

        var nEditing = null;
        var nNew = false;

        $('#sample_editable_1_new').click(function (e) {
            e.preventDefault();

            if (nNew && nEditing) {
                if (confirm("Previose row not saved. Do you want to save it ?")) {
                    saveRow(oTable, nEditing); // save
                    $(nEditing).find("td:first").html("Untitled");
                    nEditing = null;
                    nNew = false;

                } else {
                    oTable.fnDeleteRow(nEditing); // cancel
                    nEditing = null;
                    nNew = false;

                    return;
                }
            }

            var aiNew = oTable.fnAddData(['', '', '', '', '', '', '', '', '']);
            var nRow = oTable.fnGetNodes(aiNew[0]);
            editRow(oTable, nRow);
            nEditing = nRow;
            nNew = true;
        });

        table.on('click', '.delete', function (e) {
            e.preventDefault();

            if (confirm("确定要删除吗 ?") == false) {
                return;
            }

            var nRow = $(this).parents('tr')[0];
            oTable.fnDeleteRow(nRow);
            alert("删除成功");
        });

        table.on('click', '.cancel', function (e) {
            e.preventDefault();
            if (nNew) {
                oTable.fnDeleteRow(nEditing);
                nEditing = null;
                nNew = false;
            } else {
                restoreRow(oTable, nEditing);
                nEditing = null;
            }
        });

        table.on('click', '.edit', function (e) {
            e.preventDefault();

            /* Get the row as a parent of the link that was clicked on */
            var nRow = $(this).closest('tr');

            if (nEditing != null && nEditing.toString() != nRow.toString()) {
                /* Currently editing - but not this row - restore the old before continuing to edit mode */
                restoreRow(oTable, nEditing);
                editRow(oTable, nRow);
                nEditing = nRow;
            } else if (nEditing != null && nEditing.toString() == nRow.toString() && this.innerHTML == "保存") {
                /* Editing this row and want to save it */

                var jqInputs = $('input', nRow),
                 data = {
                     Id: jqInputs.eq(0).val(),
                     PName: jqInputs.eq(1).val(),
                     SinPrice: jqInputs.eq(2).val(),
                     Describe: jqInputs.eq(3).val(),
                     StartDateTime: jqInputs.eq(4).val(),
                     UpdateDateTime: jqInputs.eq(5).val(),
                     Memo: jqInputs.eq(6).val()
                 };
                $.ajax({
                    url: data.Id == '' ? 'PriceAdd' : 'PriceEdit',
                    type: 'post',
                    data: data,
                    success: function (data) {
                        !!data ? (nRow.find('[name="Id"]').val(data), saveRow(oTable, nRow),
                         alert("更新成功")) : alert("数据格式错误");
                    },
                    error: function () {
                        alert("提交失败，请检查数据格式，并保证良好网络");
                    }
                });
                nEditing = null;
            } else {
                /* No edit in progress - let's start one */
                editRow(oTable, nRow);
                nEditing = nRow;
            }
        });
    }

    return {

        //main function to initiate the module
        init: function () {
            handleTable();
        }

    };

}();