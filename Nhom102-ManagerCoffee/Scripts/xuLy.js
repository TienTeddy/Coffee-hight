﻿var number = 0;
$(document).ready(function () {
    $('#icon_tick_success').hide();
    $("#shopping-icon").hide();

    LoaiSP_GetAll();

});

function LoaiSP_GetAll() {
    $.ajax({
        url: "LoaiSanPham_show",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; var sl = 0;
            $.each(result, function (key, item) {
                html += '<button class="btn-cate" onclick="load_category('+ item.id_loai + ')">' + item.tenloai +'</button>';
            });
            $('#loaisanpham_show').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function load_category(id_loai) {
    $.ajax({
        url: "GetSanPham_id",
        type: "GET",
        data: { id : id_loai },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 0;
            $.each(result, function (key, item) {
                html += '<div class="col-lg-6 menu-section pr-lg-5">';
                html += '<div class="menu-item">';
                html += '<img src="../../Images/middle.png" alt="" class="radius-image img-fluid" />';
                html += '<div>';
                html += '<div class="row border-dot no-gutters">';
                html += '<div class="col-8 menu-item-name">';
                html += '<h6>'+item.tensanpham+'</h6> <!--tensanpham-->';
                html += '</div>';
                html += '<div class="col-4 menu-item-price text-right">';
                html += '<h6>'+item.gia+' &nbsp;VNĐ</h6> <!--gia-->';
                html += '</div>';
                html += '</div>';

                html += '<div class="row">';
                html += '<div class="col-10 menu-item-description">';
                html += '<p>'+item.mota+'</p> <!--mota-->';
                html += '</div>';
                html += '<div class="col-2" style="text-align:right">';
                html += '<form id="form-value" action="#" method="post">';
                html += '<input type="hidden" class="id_sanpham" value="' + item.id_sanpham + '">';
                html += '<input type="hidden" class="id_loai" value="' + item.id_loai + '">';
                html += '<input type="hidden" name="tensanpham" value="' + item.tensanpham + '">';
                html += '<input type="hidden" name="gia" value="' + item.gia + '">';
                html += '<input type="hidden" name="mota" value="' + item.mota + '">';
                html += '</form>';
                html += '<button id="submit-sanpham" onclick="getvalue_cart(\'' + item.id_sanpham + '\',\'' + item.id_loai + '\',\'' + item.tensanpham + '\',\'' + item.gia + '\')" class="btn btn-primary btn-lg mt-1">';
                html += '<span class="fa fa-plus" aria-hidden="true"></span>';
                html += '</button>';
                html += '</div></div></div></div></div>';
            });
            $('#menu-body').html(html);
            $('#menu-body').hide();
        },
        complete: function () {
            $("#menu-body").show({ direction: "left" }, 1000);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });  
}

var value_cart = [];
function getvalue_cart(id_sanpham, id_loai, tensanpham, gia) {
    var flat = 0;

    if (value_cart != null) {
        for (var i = 0; i < number; i++) {
            if (value_cart[i].idsanpham == id_sanpham) {
                value_cart[i].soluong += 1;
                break;
            }
            else {
                flat += 1;
            }
        }
        if (flat == number) {
            value_cart.push({
                idsanpham: id_sanpham, idloai: id_loai, tensp: tensanpham, giasp: gia, soluong: 1
            });
            number += 1;
        }
    }
    else {
        value_cart.push({
            idsanpham: id_sanpham, idloai: id_loai, tensp: tensanpham, giasp: gia, soluong: 1
        });
        number += 1;
    }

    $('#icon_tick_success').show();
    setTimeout(() => {
        $('#icon_tick_success').hide();
    }, 1380);

    setTimeout(function () {
        $("#shopping-icon").show({ direction: "left" }, 1000);
    }, 2000);
}

function order() {
    var html = ''; var sum_gia = 0;
    for (var i = 0; i < number; i++) {
        html += '<div class="table_main">';
        html += '<div class="img_item">';
        html += '<img src=\"../../Images/middle3.png\" style="width:106px;height:100px")\" />';
        html += '</div>';
        html += '<div class="infor_table">';
        html += '<h3 style="margin-top:2%"><strong>' + value_cart[i].tensp + '</strong></h3>';
        // html += '<h5>' + value_cart[i]. + '</h5>';
        html += '<input oninput="changeMoney(' + Number(value_cart[i].idsanpham) + ')" class="btn btn-warning infor_table_sl" id="' + Number(value_cart[i].idsanpham) + '" type="number" min="0" max="100" value="' + value_cart[i].soluong + '" style="width:70px;margin-top:10%"/>';
        html += '<div class="btn btn-success infor_table_dg" style="margin-top:10%">Đơn Giá: ' + Number(value_cart[i].giasp).toLocaleString('vi', { style: 'currency', currency: 'VND' }) + '</div>';
        html += '</div>';
        html += '</div>';
        sum_gia += Number(value_cart[i].giasp * value_cart[i].soluong);//*soluong 12000/x=12.000
    }
    
    $('#sum_gia').html("Tổng:&nbsp;" + sum_gia.toLocaleString('vi', { style: 'currency', currency: 'VND' }));
    $('#order_show').html(html);

}

function changeMoney(idsp) {
    var x = document.getElementById(idsp).value;
    var sum = 0;
    for (var i = 0; i < number; i++) {
        if (value_cart[i].idsanpham == idsp) {
            value_cart[i].soluong = x;
        }
        sum += value_cart[i].giasp * value_cart[i].soluong;
    }

    $('#sum_gia').html("Tổng:&nbsp;" + sum.toLocaleString('vi', { style: 'currency', currency: 'VND' }));
}

function dathang() {
    var things = [
        { id: 1, color: 'yellow' },
        { id: 2, color: 'blue' },
        { id: 3, color: 'red' }
    ];

    objectHoaDon = JSON.stringify({ 'data': value_cart });
    $.ajax({
        url: "DatHang",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: objectHoaDon,
        success: function (result) {
            if (result === 1) {
                window.location.replace('../TaiKhoan/Infor');
            }
            /*else if (result === -1) {
                alert("Error Order!");
            }
            else {
                alert("Bạn chưa chọn sản phẩm.");
            }
            */
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}