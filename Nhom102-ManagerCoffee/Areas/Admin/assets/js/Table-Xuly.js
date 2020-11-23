$(document).ready(function () {
    hide();
});

function hide() {
    $("#Table-SanPham").hide();
    $("#Table-LoaiSP").hide();
    $("#Table-HoaDon").hide();
    $("#Table-Coupon").hide();
    $("#Table-TaiKhoan").hide();
    $("#Table-KhachHang").hide();
    $("#Table-NhanVien").hide();
    $("#Table-LichSu").hide();
}
//Get SanPham All
function SanPham_GetAll() {
    hide();
    $.ajax({
        url: "SanPham_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>';
                html += '<span class="custom-checkbox">';
                html += '<input type="checkbox" id="checkbox2" name="options[]" value="'+i+'">';
                html += '<label for="checkbox2"></label>';
                html += '</span>';
                html += '</td>';

                html += '<td>' + item.id_sanpham + '</td >';
                html += '<td>' + item.tensanpham + '</td >';
                html += '<td>' + item.id_loai + '</td>';
                html += '<td><img src="../../Areas/Admin/assets/img/Coca-Cola-Can-icon.png" class="image-products" /></td>';
                html += '<td>' + item.gia + '</td >';
                html += '<td>' + item.mota + '</td >';
                html += '<td>' + item.soluong + '</td >';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-SanPham" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
                html += '<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>';
                html += '</div>';
                html += '</td >';
                html += '</tr>';
                i = i + 1;
            });
            $('#sanpham-context').html(html);
            $("#Table-SanPham").show({ direction: "right" }, 1500);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Get LoaiSanPham All
function LoaiSanPham_GetAll() {
    hide();
    $.ajax({
        url: "LoaiSanPham_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>';
                html += '<span class="custom-checkbox">';
                html += '<input type="checkbox" id="checkbox2" name="options[]" value="' + i + '">';
                html += '<label for="checkbox2"></label>';
                html += '</span>';
                html += '</td>';

                html += '<td>' + item.id_loai + '</td >';
                html += '<td>' + item.tenloai + '</td >';
                html += '<td>' + item.mota + '</td>';
                html += '<td><img src="../../Areas/Admin/assets/img/Coca-Cola-Can-icon.png" class="image-products" /></td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-SanPham" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
                html += '<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>';
                html += '</div>';
                html += '</td >';
                html += '</tr>';
                i = i + 1;
            });
            $('#loaisanpham-context').html(html);
            $("#Table-LoaiSP").show({ direction: "right" }, 1500);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Get Coupon All
function Coupon_GetAll() {
    hide();
    $.ajax({
        url: "CouPon_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>';
                html += '<span class="custom-checkbox">';
                html += '<input type="checkbox" id="checkbox2" name="options[]" value="' + i + '">';
                html += '<label for="checkbox2"></label>';
                html += '</span>';
                html += '</td>';

                html += '<td>' + item.id_coupon + '</td >';
                html += '<td>' + item.tencoupon + '</td >';
                html += '<td>' + item.lifetime + '</td>';
                html += '<td>' + item.thestart + '</td>';
                html += '<td>' + item.theend + '</td>';
                html += '<td>' + item.discount + '</td>';
                html += '<td>' + item.status + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-SanPham" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
                html += '<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>';
                html += '</div>';
                html += '</td >';
                html += '</tr>';
                i = i + 1;
            });
            $('#coupon-context').html(html);
            $("#Table-Coupon").show({ direction: "right" }, 1500);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Get Coupon All
function HoaDon_GetAll() {
    hide();
    $.ajax({
        url: "HoaDon_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>';
                html += '<span class="custom-checkbox">';
                html += '<input type="checkbox" id="checkbox2" name="options[]" value="' + i + '">';
                html += '<label for="checkbox2"></label>';
                html += '</span>';
                html += '</td>';

                html += '<td>' + item.id_hoadon + '</td >';
                html += '<td>' + item.id_khachhang + '</td >'; //tenkh  
                html += '<td>' + item.id_sanpham + '</td>';
                //html += '<td>' + item.id_loai + '</td>';
                html += '<td>' + item.thoigian + '</td>';
                html += '<td>' + item.tonggia + '</td>';
                html += '<td>' + item.discount + '</td>';
                //html += '<td>' + item.diemcong + '</td>';
                html += '<td>' + item.soluong + '</td>';
                html += '<td>' + item.trangthai + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-SanPham" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
                html += '<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>';
                html += '</div>';
                html += '</td >';
                html += '</tr>';
                i = i + 1;
            });
            $('#hoadon-context').html(html);
            $("#Table-Coupon").show({ direction: "right" }, 1500);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Get TaiKhoan All
function TaiKhoan_GetAll() {
    hide();
    $.ajax({
        url: "TaiKhoan_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>';
                html += '<span class="custom-checkbox">';
                html += '<input type="checkbox" id="checkbox2" name="options[]" value="' + i + '">';
                html += '<label for="checkbox2"></label>';
                html += '</span>';
                html += '</td>';

                html += '<td>' + item.id_taikhoan + '</td >';
                html += '<td>' + item.taikhoan + '</td>';
                html += '<td>' + item.matkhau + '</td>';
                html += '<td>' + item.loaitk + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-SanPham" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
                html += '<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>';
                html += '</div>';
                html += '</td >';
                html += '</tr>';
                i = i + 1;
            });
            $('#taikhoan-context').html(html);
            $("#Table-TaiKhoan").show({ direction: "right" }, 1500);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Get TaiKhoan All
function KhachHang_GetAll() {
    hide();
    $.ajax({
        url: "KhachHang_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>';
                html += '<span class="custom-checkbox">';
                html += '<input type="checkbox" id="checkbox2" name="options[]" value="' + i + '">';
                html += '<label for="checkbox2"></label>';
                html += '</span>';
                html += '</td>';

                html += '<td>' + item.id_khachhang + '</td >';
                html += '<td>' + item.id_taikhoan + '</td>';
                html += '<td>' + item.hoten + '</td>';
                html += '<td>' + item.gioitinh + '</td>';
                html += '<td>' + item.diachi + '</td>';
                html += '<td>' + item.sdt + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-SanPham" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
                html += '<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>';
                html += '</div>';
                html += '</td >';
                html += '</tr>';
                i = i + 1;
            });
            $('#khachhang-context').html(html);
            $("#Table-KhachHang").show({ direction: "right" }, 1500);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Get NhanVien All
function NhanVien_GetAll() {
    hide();
    $.ajax({
        url: "NhanVien_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>';
                html += '<span class="custom-checkbox">';
                html += '<input type="checkbox" id="checkbox2" name="options[]" value="' + i + '">';
                html += '<label for="checkbox2"></label>';
                html += '</span>';
                html += '</td>';

                html += '<td>' + item.id_nhanvien + '</td >';
                html += '<td>' + item.id_taikhoan + '</td>';
                html += '<td>' + item.id_calamviec + '</td>';
                html += '<td>' + item.hoten + '</td>';
                html += '<td>' + item.gioitinh + '</td>';
                html += '<td>' + item.diachi + '</td>';
                html += '<td>' + item.sdt + '</td>';
                html += '<td>' + item.tonggiolam + '</td>';
                html += '<td>' + item.tongtien + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-SanPham" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
                html += '<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>';
                html += '</div>';
                html += '</td >';
                html += '</tr>';
                i = i + 1;
            });
            $('#nhanvien-context').html(html);
            $("#Table-NhanVien").show({ direction: "right" }, 1500);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Get NhanVien All
function LichSu_GetAll() {
    hide();
    $.ajax({
        url: "LichSu_GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>';
                html += '<span class="custom-checkbox">';
                html += '<input type="checkbox" id="checkbox2" name="options[]" value="' + i + '">';
                html += '<label for="checkbox2"></label>';
                html += '</span>';
                html += '</td>';

                html += '<td>' + i + '</td >';
                html += '<td>' + item.actions + '</td>';
                html += '<td>' + item.thoigian + '</td>';
                html += '<td>' + item.tensanpham + '</td>';
                html += '<td>' + item.namemember + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-SanPham" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
                html += '<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>';
                html += '</div>';
                html += '</td >';
                html += '</tr>';
                i = i + 1;
            });
            $('#lichsu-context').html(html);
            $("#Table-LichSu").show({ direction: "right" }, 1500);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}