var arrayLoaiSP = new Array();
var arraySanPham = new Array();
$(document).ready(function () {
    //call spinner off
    $('#spinner-action').hide();

    $(".table_left_").hide();
    SanPham_GetAll();
    LoaiSP_GetAll();

    Table_GetAll();

    $("#submit_table_left").click(function () {
        var checks = $("input[type='checkbox']:checked"); // returns object of checkeds.

        var id_sanpham = $('#idsanpham_left_table').text();
        var soluong = $('#soluong_left_table').val();

        if (checks) {

            var data = new Array();
            //get value
            for (var i = 0; i < checks.length; i++) {
                //console.log($(checks[i]).val()); // or do what you want
                data[i] = $(checks[i]).val();
            }
            //console.log(data);
            //data
            $.ajax({
                url: "Push_TableCT?data=" + data + '&id_sanpham=' + id_sanpham + '&soluong=' + soluong,
                type: "GET",
                //data: JSON.stringify({ data: data1, id_sanpham: id_sanpham1, soluong: soluong1 }),
                dataType: "json",
                beforeSend: function () {
                    $('#spinner-action').show(); //Hide your spinner after your call
                },
                success: function (result) {
                    if (result == 1) {
                        Table_GetAll();
                    }
                    else {
                        alert("Không thể thêm món!");
                    }
                },
                complete: function () { // Set our complete callback, adding the .hidden class and hiding the spinner.
                    setTimeout(() => {
                        $('#spinner-action').hide();
                    }, 1100);
                },
                statusCode: {
                    404: function () {
                        alert("page not found");
                    }
                },
                error: function (errormessage) {
                    //alert(errormessage.responseText);
                    $('#tableshow').html(errormessage.responseText);
                }
            });
        }
    });

});

function Table_GetAll() {
    $.ajax({
        url: "Table_show",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //table main
            var html1 = ''; i = 0;
            $.each(result, function (key, item) {
                if (item.yesbill_nobill == 'Chưa Thanh Toán') {
                    html1 += '<div class="table_ btn nobill" id="table-1" onclick="table_show_item('+ item.id_table +')" data-toggle="modal" data-target="#largeModal">' + item.tentable + '</div>';
                    //red
                }
                else if (item.yesbill_nobill == 'Đã Thanh Toán' && item.int_out == 'Chưa Rời Đi') {
                    html1 += '<div class="table_ btn yesbill_noout" id="table-1" onclick="table_show_item(' + item.id_table +')" data-toggle="modal" data-target="#largeModal">' + item.tentable + '</div>';
                    //yellow
                }
                else {
                    html1 += '<div class="table_ btn yesbill_out" id="table-1" onclick="table_show_item(' + item.id_table +')" data-toggle="modal" data-target="#largeModal">' + item.tentable + '</div>';
                    //blue
                }
            });

            $('#table_show_1').html(html1);

            //table left
            var html2 = '';
            $.each(result, function (key, item) {
                if (item.yesbill_nobill == 'Chưa Thanh Toán') {
                    html2 += '<div class="table_left btn option_table_left nobill">';
                    html2 += '<h1 style="position:absolute;margin-left:11px;margin-top:7px">' + item.tentable + '</h1>';
                    html2 += '<input type="checkbox" style="width:72px;height:76px;opacity:0.4;margin:-10px -15px;" value="' + item.id_table + '" />';
                    html2 += '</div>';
                }
                else if (item.yesbill_nobill == 'Đã Thanh Toán' && item.int_out == 'Chưa Rời Đi') {
                    html2 += '<div class="table_left btn option_table_left yesbill_noout">';
                    html2 += '<h1 style="position:absolute;margin-left:11px;margin-top:7px">' + item.tentable + '</h1>';
                    html2 += '<input type="checkbox" style="width:72px;height:76px;opacity:0.4;margin:-10px -15px;" value="' + item.id_table + '" />';
                    html2 += '</div>';
                }
                else {
                    html2 += '<div class="table_left btn option_table_left yesbill_out">';
                    html2 += '<h1 style="position:absolute;margin-left:11px;margin-top:7px">' + item.tentable + '</h1>';
                    html2 += '<input type="checkbox" style="width:72px;height:76px;opacity:0.4;margin:-10px -15px;" value="' + item.id_table + '" />';
                    html2 += '</div>';
                }
            });
            $('#table_show_2').html(html2);

            //changer end
            $('.nobill').css({ 'background-color': 'OrangeRed' });
            $('.yesbill_noout').css({ 'background-color': 'Yellow' });
            $('.yesbill_out').css({ 'background-color': 'cadetblue' });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });  
}
function table_show_item(id_table) {
    var id = Number(id_table);
    
    $.ajax({
        url: "Get_TableCT/"+id,
        type: "GET",
       // data: { data:id },
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                //item.loaisanpham
                //item.tensanpham
                //item.gia
                //item.soluong
                //item.thanhtien
                //"~/Images/no-image-found.png" class="img_item_"
                html += '<div class="table_main">';
                html += '<div class="img_item">';
                html += '<img src=\"../../Images/no-image-found.png\" style="width:106px;height:100px")\" />'; //Areas/admin/assets/Images/no-image-found.png
                html += '</div>';
                html += '<div class="infor_table">';
                html += '<h3 style="margin-top:2%"><strong>' + item.tensanpham + '</strong></h3>';
                html += '<h5>' + item.loaisanpham + '</h5>';
                html += '<div class="btn btn-warning infor_table_sl">SL:' + item.soluong + '</div>';
                html += '<div class="btn btn-success infor_table_dg">Đơn Giá:' + item.gia + '</div>';
                html += '</div>';
                html += '</div>';
            });
            $('#tableshow').html(html);
        },
        statusCode: {
            404: function () {
                alert("page not found");
            }
        },
        error: function (errormessage) {
            //alert(errormessage.responseText);
            $('#tableshow').html(errormessage.responseText);
        }
    });
}


function SanPham_GetAll() {
    $.ajax({
        url: "SanPham_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 0;
            $.each(result, function (key, item) {
                html += '<tr class="' + item.id_loai + '" onclick="loadtable_(\'' + item.id_sanpham + '\',\'' + item.id_loai + '\',\'' + item.tensanpham + '\',\'' + item.gia + '\')" id="' + item.id_sanpham + '">';
                html += '<td>' + item.tensanpham + '</td>';
                html += '<td>' + item.soluong + '</td>';
                html += '<td>' + item.gia + '</td>';
                //html += '<td><a href="#" onclick="return getbyID(' + item.EmployeeID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.EmployeeID + ')">Delete</a></td>';
                html += '</tr>';
                arraySanPham[i] = item.id_sanpham;
                i += 1;
            });
            $('#sanpham').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });  
}

function LoaiSP_GetAll() {
    $.ajax({
        url: "LoaiSanPham_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; var sl = 0;
            $.each(result, function (key, item) {
                arrayLoaiSP[sl] = item.id_loai;
                sl += 1;
                html += '<div class="col-md-3 btn-item btn btn-info" onclick="optionShow_Loaisp(' + item.id_loai+')" id="' + item.id_loai+'">'+item.tenloai +'</div>';
            });
            $('#LoaiSanPham').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function optionShow_Loaisp(id_loai) {
    //SanPham_GetAll();

    var flag = 0;
    var id_l = "." + id_loai + "";
    for (var i = 0; i < arrayLoaiSP.length; i++) {
        if (Number(id_loai) !== Number(arrayLoaiSP[i])) {
            $("." + arrayLoaiSP[i] + "").hide({ direction: "top" }, 1100);
        }
    }
    
        //$(id_l).fadeOut(1000);
}
function optionShow_() {
    SanPham_GetAll();
}


function loadtable_(id_sanpham,id_loai,tensanpham,gia) {
    $(".table_sanpham").hide({ direction: "left" }, 1000);

    setTimeout(function () {
        $(".table_left_").show({ direction: "left" }, 1000);
    }, 500);

    $('#idsanpham_left_table').html(id_sanpham);
    $('#tensanpham_left_table').html(tensanpham);
    $('#tenloai_left_table').html(id_loai);
    $('#gia_left_table').html(gia);
}

var cancel = document.getElementById("cancel_table_left");
cancel.onclick = function () {
    $(".table_left_").hide({ direction: "right" }, 1000);
    setTimeout(function () {
        $(".table_sanpham").show({ direction: "right" }, 1000);
    }, 500);
}