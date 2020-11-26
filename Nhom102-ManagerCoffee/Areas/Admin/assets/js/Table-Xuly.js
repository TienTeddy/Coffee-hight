var changestart = '';
var changeend = '';
$(document).ready(function () {
    hide();

});
function start(e) {
    changestart = e.target.value;
}
function end(e) {
    changeend = e.target.value;

    $('#add-lifetime').val(date_diff_indays(changestart, changeend) + ' Days');
}

function date_diff_indays(date1, date2) {
    dt1 = new Date(date1);
    dt2 = new Date(date2);
    return Math.floor((Date.UTC(dt2.getFullYear(), dt2.getMonth(), dt2.getDate()) - Date.UTC(dt1.getFullYear(), dt1.getMonth(), dt1.getDate())) / (1000 * 60 * 60 * 24));
}

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
                html += '<a href="#Edit-SanPham" onclick="Edit_SanPham(\'' + item.tensanpham + '\',\'' + item.id_loai + '\',\'' + item.hinhanh + '\',\'' + item.gia + '\',\'' + item.soluong + '\',\'' + item.mota + '\' )"  class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
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
function Edit_SanPham(tensanpham, id_loai, hinhanh, gia, soluong, mota) {
    $('#sanpham-edit-tensanpham').val(tensanpham);
    $('#sanpham-edit-id_loai').val(id_loai);
    //$('#sanpham-edit-hinhanh').val(hinhanh);
    $('#sanpham-edit-gia').val(gia);
    $('#sanpham-edit-soluong').val(soluong);
    $('#sanpham-edit-mota').val(mota);
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
                html += '<a href="#Edit-LoaiSP" onclick="Edit_LoaiSanPham(\'' + item.id_loai + '\',\'' + item.tenloai + '\',\'' + item.hinhanh + '\',\'' + item.mota + '\' )" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
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
function Edit_LoaiSanPham(id_loai, tenloai, hinhanh, mota) {
    $('#loai-edit-id_loai').val(id_loai);
    $('#loai-edit-tenloai').val(tenloai);
    //$('#loai-edit-hinhanh').val(hinhanh);
    $('#loai-edit-mota').val(mota);
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

                html += '<td>' + item.Ma_Coupon + '</td >';
                html += '<td>' + item.tencoupon + '</td >';
                html += '<td><input style="background:#CCFF99;font-weight: bold;" type="text" value="' + item.lifetime + '" readonly/></td>';
                html += '<td><input type="date" value="' + item.thestart + '" readonly /></td>';
                html += '<td><input type="date" value="' + item.theend + '" readonly /></td>';
                html += '<td>' + item.discount + '%</td>';
                html += '<td>' + item.status + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-Coupon" onclick="Edit-Coupon(\'' + item.id_loai + '\',\'' + item.tenloai + '\',\'' + item.hinhanh + '\',\'' + item.mota + '\' )" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
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

//Get HoaDon All
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

                html += '<td>' + item.id_hoadon + '</td>';
                html += '<td>' + item.tenkhachhang + '</td >'; //tenkh  
                //html += '<td>' + item.id_loai + '</td>';
                html += '<td>' + item.thoigian + '</td>';
                html += '<td>' + item.tonggia + '</td>';
                html += '<td>' + item.discount + '</td>';
                //html += '<td>' + item.diemcong + '</td>';
                html += '<td>' + item.soluong + '</td>';
                html += '<td>' + item.trangthai + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-HoaDon" onclick="Edit_HoaDon(\'' + item.id_hoadon + '\',\'' + item.tenkhachhang + '\',\'' + item.thoigian + '\',\'' + item.tonggia + '\',\'' + item.discount + '\',\'' + item.soluong + '\',\'' + item.trangthai + '\' )" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
                html += '<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>';
                html += '</div>';
                html += '</td >';
                html += '</tr>';
                i = i + 1;
            });
            $('#hoadon-context').html(html);
            $("#Table-HoaDon").show({ direction: "right" }, 1500);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Edit_HoaDon(id_hoadon, tenkhachhang, thoigian, tonggia, discount, soluong, trangthai) {
    $('#hoadon-edit-id_hoadon').val(id_hoadon);
    $('#hoadon-edit-id_khachhang').val(tenkhachhang);
    $('#hoadon-edit-thoigian').val(thoigian);
    $('#hoadon-edit-soluong').val(soluong);
    $('#hoadon-edit-discount').val(discount);
    $('#hoadon-edit-tonggia').val(tonggia);
    $('#hoadon-edit-trangthai').val(trangthai);
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
                html += '<td>' + item.taikhoan1 + '</td>';
                html += '<td>' + item.matkhau + '</td>';
                html += '<td>' + item.loaitk + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-TaiKhoan" onclick="Edit_TaiKhoan(\'' + item.id_taikhoan + '\',\'' + item.taikhoan1 + '\',\'' + item.matkhau + '\',\'' + item.loaitk + '\' )" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
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
function Edit_TaiKhoan(id_taikhoan, taikhoan1, matkhau, loaitk) {
    $('#taikhoan-edit-id_taikhoan').val(id_taikhoan);
    $('#taikhoan-edit-taikhoan').val(taikhoan1);
    $('#taikhoan-edit-loaitk').val(loaitk);
    $('#taikhoan-edit-matkhau').val(matkhau);
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
                html += '<a href="#Edit-KhachHang" onclick="Edit_KhachHang(\'' + item.id_khachhang + '\',\'' + item.id_taikhoan + '\',\'' + item.hoten + '\',\'' + item.gioitinh + '\',\'' + item.diachi + '\',\'' + item.sdt + '\' )" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
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
function Edit_KhachHang(id_khachhang, id_taikhoan, hoten, gioitinh, diachi, sdt) {
    $('#khachhang-edit-id_khachhang').val(id_khachhang);
    $('#khachhang-edit-id_taikhoan').val(id_taikhoan);
    $('#khachhang-edit-hoten').val(hoten);
    $('#khachhang-edit-gioitinh').val(gioitinh);
    $('#khachhang-edit-diachi').val(diachi);
    $('#khachhang-edit-sdt').val(sdt);
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
                //html += '<td>' + item.id_taikhoan + '</td>';
                html += '<td>' + item.id_calamviec + '</td>';
                html += '<td>' + item.hoten + '</td>';
                html += '<td>' + item.gioitinh + '</td>';
                html += '<td>' + item.diachi + '</td>';
                html += '<td>' + item.sdt + '</td>';
                html += '<td>' + item.tonggiolam + '</td>';
                html += '<td>' + item.tongtien + '</td>';
                html += '<td>';
                html += '<div id="CRUD-button">';
                html += '<a href="#Edit-NhanVien" onclick="Edit_NhanVien(\'' + item.id_nhanvien + '\',\'' + item.id_calamviec + '\',\'' + item.hoten + '\',\'' + item.gioitinh + '\',\'' + item.diachi + '\',\'' + item.sdt + '\',\'' + item.tonggiolam + '\',\'' + item.tongtien + '\' )" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>';
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
function Edit_NhanVien(id_nhanvien, id_calamviec, hoten, gioitinh, diachi, sdt,tonggiolam, tongtien) {
    $('#nhanvien-edit-id_nhanvien').val(id_nhanvien);
    $('#nhanvien-edit-id_calamviec').val(id_calamviec);
    $('#nhanvien-edit-hoten').val(hoten);
    $('#nhanvien-edit-gioitinh').val(gioitinh);
    $('#nhanvien-edit-diachi').val(diachi);
    $('#nhanvien-edit-sdt').val(sdt);
    $('#nhanvien-edit-tonggiolam').val(tonggiolam);
    $('#nhanvien-edit-tongtien').val(tongtien);
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

function Coupon_TenKH() {
    $.ajax({
        url: "Coupon_TenKH",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; i = 1;
            $.each(result, function (key, item) {
                html += '<option value="' + item.id_khachhang + '">' + item.hoten + '</option>';
            });
            $('#Coupon-tenkhachhang').html(html);
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function AddCoupon() {
    var tenkh = "";
    //$('#Coupon-tenkhachhang').change(function () {
    //    tenkh = this.value;
    //});

    var values = [
        {
            id_khachhang: $('#Coupon-tenkhachhang').val(),
            tencoupon: $('#add-tencoupon').val(),
            lifetime: $('#add-lifetime').val(),
            thestart: $('#add-thestart').val(),
            theend: $('#add-theend').val(),
            discount: $('#add-discount').val()
        }
    ];

    objectHoaDon = JSON.stringify({ 'data': values });
    //addcoupon
    $.ajax({
        url: "AddCoupon",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: objectHoaDon,
        success: function (result) {
            alert("Success.");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}