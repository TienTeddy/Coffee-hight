
//function removeData(chart) {
//    chart.data.labels.pop();
//    chart.data.datasets.forEach((dataset) => {
//        dataset.data.pop();
//    });
//    chart.update();
//}

//addData(myChart, 'Tháng', [12]);

var tongsanpham = 10;
var sanphamdaban = 10;
var sanphamtonkho = 10;

function CreateThongKe() {
    $.ajax({
        url: "ThongKe",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            CountSoDon_Ngay();
            DoanhThu_Ngay();
            CountSoDon_Thang();
            DoanhThu_Thang();

            CountSanPham();
            CountSanPhamDaBan();
            sanphamtonkho = tongsanpham - sanphamdaban;
            
            setTimeout(function () {
                drawChart(tongsanpham, sanphamdaban, sanphamtonkho);
                //$(".table_sanpham").show({ direction: "right" }, 1000);
            }, 1000);
            $("#Table-Chart").show({ direction: "right" }, 1000);
            //alert(typeof (sanphamtonkho));
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//get count<HoaDon> số đơn trong ngày
function CountSoDon_Ngay() {
    $.ajax({
        url: "CountSoDon_Ngay",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#Counttrong-ngay").val(data);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//get count<D> doanh thu trong ngày
function DoanhThu_Ngay() {
    $.ajax({
        url: "DoanhThu_Ngay",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#doanhthu-ngay").val(data.toLocaleString('vi', { style: 'currency', currency: 'VND' }));
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//get count<HoaDon> số đơn trong thang
function CountSoDon_Thang() {
    $.ajax({
        url: "CountSoDon_Thang",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#Counttrong-thang").val(data);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//get count<D> doanh thu trong ngày
function DoanhThu_Thang() {
    $.ajax({
        url: "DoanhThu_Thang",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#doanhthu-thang").val(data.toLocaleString('vi', { style: 'currency', currency: 'VND' }));
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//get TongSanPham
function CountSanPham() {
    $.ajax({
        url: "CountSanPham",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            tongsanpham = data;
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//get TongSanPham
function CountSanPhamDaBan() {
    $.ajax({
        url: "CountSanPhamDaBan",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            sanphamdaban = data;
            sanphamtonkho = tongsanpham - sanphamdaban;
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function drawChart(a, b, c) {
    var data_sanpham = {
        labels: ["", "", ""],
        datasets: [{
            label: "Tổng Sản Phẩm",
            backgroundColor: 'rgba(255, 99, 132, 0.2)',
            borderColor: 'rgba(255,99,132,1)',
            borderWidth: 2,
            data: [a],
        }]
    };
    var ctx_sanpham = $("#chart-hoadon").get(0).getContext("2d");

    var myBarChart_sanpham = new Chart(ctx_sanpham, {
        type: "bar", //line, bar, radar, doughnut, pie, polar area, bubble, scatter
        data: data_sanpham,
    });


    //Add Chart SanPham
    var SanPhamDaBan = {
        label: "SP Đã Bán",
        backgroundColor: 'rgba(99, 255, 132, 0.2)',
        borderColor: 'rgba(99, 255, 132, 1)',
        borderWidth: 1,
        data: [b],
    }
    var SanPhamTonKho = {
        label: "SP Tồn Kho",
        backgroundColor: 'rgba(132,99, 255, 0.2)',
        borderColor: 'rgba(132,99, 255, 1)',
        borderWidth: 1,
        data: [12],
    }
    data_sanpham.datasets.push(SanPhamDaBan);
    data_sanpham.datasets.push(SanPhamTonKho);
    myBarChart_sanpham.update();
}




$('#chart-button2').click(function () {
    var newDataset = {
        label: "Năm",
        backgroundColor: 'rgba(99, 255, 132, 0.2)',
        borderColor: 'rgba(99, 255, 132, 1)',
        borderWidth: 1,
        data: [20, 30, 40, 40, 50, 60, 80],
    }
    data_hoadon.datasets.push(newDataset);
    myBarChart_hoadon.update();
});



