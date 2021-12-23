/// <reference path="../angular.min.js" />

//var myapp = angular.module("AdminApp", []);
//myapp.controller("LoaiSPController", function ($scope, $http)
//{
//     //Lấy về tất cả loại sản phẩm
//    $http({
//        method: "get",
//        url: "/Home/GetLoaiSanPham"
//    }).then(function Success(d) {
//        $scope.LoaiSPs = d.data;
//    }, function (error) {
//        alert('hekk');
//    });
//});

//MEMU ĐỘNG
var homeapp = angular.module("CustomerApp", ['angularUtils.directives.dirPagination'])//['angularUtils.directives.dirPagination']);
homeapp.controller("MenuController",
    function ($scope, $rootScope, $http, $http) {
        $http.get('/Home/GetCategory').then(function (d) {
            $rootScope.listLoai = d.data;
        },
            function (e) { alert("g") });
        $scope.SelectLoai = function (l) {
            localStorage.setItem("MaLoai", l);
        }

    });


//LẤY SẢN PHẨM
homeapp.controller("SanPhamControllers",
    function ($rootScope, $scope, $http) {
        $http.get('/SanPham/GetProduct').then(function Success(d) {
            $rootScope.lsp = d.data;
        },
        function (error) {
            alert('That bai');
        });


        //$scope.CTSP = function (a) {
        //    localStorage.setItem("MaSP", a);
        //};

        $scope.SelectSanPham = function (masp) {
            localStorage.setItem("MaSP", masp);
        };

        $scope.AddGioHang = function (s) {
            $http({
                method: 'post',
                url: '/GioHang/AddGioHang',
                datatype: 'json',
                params: { ss: JSON.stringify(s) }
            }).then(function (res) {
                if (res.status) {
                    $window.location.href = '/DatHang/Index';
                }
            })
        }
    });

//SẮP XẾP DỮ LIỆU
homeapp.controller("SapXepController",
    function ($scope, $rootScope, $http) {
        $http.get('/Home/GetProduct').then(function (d) {
            $rootScope.SanPham = d.data;
        },
            function (e) { alert("g") });
        $rootScope.sortcolumn = "MaSP";
        $rootScope.sortcolumn = "TenSP";
        $rootScope.reverse = true;
        $rootScope.direct = "Ascending";
        $rootScope.maxSize = 3; // limit number for pagination display number. 
        $rootScope.totalCount = 0; // total number of items in all pages. initialize as a zero 
        $rootScope.pageIndex = 1; // current page number. first page is 1
        $rootScope.pageSize = 8; // maximum number of items per page. 
        $rootScope.searchName = "";
        $rootScope.maloai = '';
        //Khi nhấn button sẽ chuyển đổi chiều sắp xếp
        $rootScope.Chon = function (d) {
            if ($rootScope.direct == "Ascending") {
                $rootScope.reverse = false;
                $rootScope.direct = "Decreasing";
            }
            else {
                $rootScope.reverse = true;
                $rootScope.direct = "Ascending";
            }
        };
        //Lấy sản phẩm hiển thị lên giao diện
        $scope.GetSanPhams = function (index) {
            $http.get('Admin/SanPham/GetSanPhamPT',
                {
                    params: {
                        pageIndex: index,
                        pageSize: $rootScope.pageSize, productName: $rootScope.searchName
                    }
                }).then(function (d) {
                    $scope.SanPham = d.data.SanPhams;
                    $rootScope.totalCount = d.data.totalCount

                }, function (error) { alert('Failed'); });
        }
        $scope.GetSanPhams($scope.pageIndex);

    });
//homeapp.controller("SapXepController", function ($scope, $rootScope, $http, $window) {
//    $http.get('/SanPham/GetProduct').then(function Success(d) {
//        $rootScope.lsp = d.data;
//    },
//        function (error) {
//            alert('That bai');
//        });
//    $scope.SelectSanPham = function (masp) {
//        localStorage.setItem("MaSP", masp);
//    };
//    //Begin sort
//    $rootScope.sortcolumn = "MaSP";
//    $rootScope.reverse = true;
//    $rootScope.direct = "Ascending";

//    $rootScope.maxSize = 3; // limit number for pagination display number.
//    $rootScope.totalCount = 0; // total number of items in all pages. initialize as a zero 
//    $rootScope.pageIndex = 1; // current page number. first page is 1
//    $rootScope.pageSize = 3; // maximum number of items per page. 
//    $rootScope.searchName = "";

//    $rootScope.maloai = '';
//    //Khi nhấn button sẽ chuyển đổi chiều sắp xếp
//    $rootScope.Chon = function (d) {
//        if ($rootScope.direct == "Ascending") {
//            $rootScope.reverse = false;
//            $rootScope.direct = "Decreasing";
//        }
//        else {
//            $rootScope.reverse = true;
//            $rootScope.direct = "Ascending";
//        }
//    };

//    //Lấy sản phẩm hiển thị lên giao diện
//    $scope.GetSanPhams = function () {
//        var MaLoai = localStorage.getItem("MaLoai");
//        if (MaLoai == undefined) {
//            MaLoai = "";
//        }

//        $http.get('/Home/GetSanPhamPT',
//            {
//                params: {
//                    maloai: MaLoai, pageIndex: $rootScope.pageIndex, pageSize:
//                        $rootScope.pageSize, productName: $rootScope.searchName
//                }
//            }).then(function (d) {
//                $scope.ListSanPham = d.data;
//                $rootScope.totalCount = $scope.ListSanPham.totalCount

//            }, function (error) { alert('Failed'); });
//    };
//    $scope.GetSanPhams();
//    $scope.SelectLoai = function (l) {
//        localStorage.setItem("MaLoai", l);
//        $scope.GetSanPhams();
//    }
    

//});

// LẤY DANH SÁCH SẢN PHẦM THEO LOẠI
homeapp.controller("SanPhamLoaiController", function ($scope, $rootScope, $http, $window) {

    var maloai = localStorage.getItem("MaLoai") //;
    $http({
        method: "get",
        url: '/SanPham/GetSanPhamTheoLoai',
        params: { MaLoai: maloai }
    }).then(function success(d) {
        $scope.ListSanPham = d.data;
    }, function error(e) { alert("Error") });

    $scope.SelectSanPham = function (masp) {
        localStorage.setItem("MaSP", masp);
    }

    $rootScope.AddCart = function (s) {
        $http({
            method: 'post',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: { s: s }
        }).then(function (d) {
            $http({
                method: 'get',
                datatype: 'json',
                url: '/GioHang/GetCarts',

            }).then(function success(d) {
                alert("Gioloi")
                $rootScope.dsDonHang = d.data.dsDonHang;
                alert(d.data)
                $rootScope.SL = d.data.SoLuong;
                $rootScope.TT = d.data.ThanhTien;
                if ($rootScope.dsDonHang.length > 0) {
                    $scope.Het = "false";
                }
                else { $scope.Het = "true"; }
                console.log("So Luong:"); console.log($rootScope.SL);
                console.log("Thanh Tien:"); console.log($rootScope.TT);
            }, function error(e) { alert("Gio Hang loi"); });
        }, function () { alert("Lỗi"); });
    };

    //$rootScope.KiemTraDangNhap = function () {
    //    function(d) {
    //        if (d.data.login == "1") {
    //            $rootScope.DangNhap = "";
    //            $rootScope.Customer = d.data.Khach;
    //            console.log(JSON.stringify($rootScope.Khach));
    //            $http.get('/GioHang/GetCarts').then(function (d) {

    //            })
    //        }
    //    }
    //}

});

// CHI TIẾT SẢN PHẨM
homeapp.controller("DetailProduct", function ($scope,$http) {
    $http({
        method: "get",
        url: "/ChiTietSP/GetProduct",
        params: { MaSP: localStorage.getItem("MaSP") }
    }).then(function success(d) {
        $scope.SanPham = d.data;
    },
        function error() { alert("error") });
    //$scope.SelectSanPham = function (masp) {
    //    localStorage.setItem("MaSP", masp);
    //}

});

//đặt hàng
homeapp.controller("DatHangController", function ($rootScope, $scope, $http, $window) {
    $rootScope.KhachHang = null;
    $http.get('/DatHang/GetCustomer').then(function (d) {
        $rootScope.KhachHang = d.data.khach;
    }, function () {
        alert("Customer Lỗi")
    })
    //$rootScope.DatHang = function () {
    //    $rootScope.DonHang.Khach = $rootScope.Khach;
    //    $rootScope.DonHang.TongTien = $rootScope.ThanhTien;
    //    $rootScope.DonHang.LCtDonHang = $rootScope.dsDonHang;
    //    $http({
    //        method: 'Post',
    //        datatype: 'Json',
    //        url: 'DatHang/DatHang',
    //        data: JSON.stringify($rootScope.DonHang)
    //    }).then(function (d) { }, function() { });
    //};
});


//// lấy toàn bộ sản phẩm 
homeapp.controller("ProductController", function ($scope, $http) {
    $http({
        method: "get",
        url: '/Home/GetProduct'
    }).then(function success(d) {
        $scope.ListSanPham = d.data;
        console.log(data);
    }, function error(e) { alert("Error") });

});

// giỏ hàng
homeapp.controller("CartController", function ($rootScope, $scope, $http, $window) {
    $rootScope.DangNhap = "#myModal";
    $rootScope.DatHang = "";
    $rootScope.SoLuong = 0;
    $rootScope.Log = "Login";

    $rootScope.KhachHang = null;
    /*lấy về các sản phẩm tring giỏ hàng*/
    $http({
        method: 'get',
        datatype: 'json',
        url: '/GioHang/GetCarts',
    }).then(function success(d) {
        $rootScope.dsDonHang = d.data.dsDonHang;
        $rootScope.SL = d.data.SoLuong;
        $rootScope.TT = d.data.ThanhTien;
        if ($rootScope.dsDonHang.length > 0) {
            $scope.Het = "false";
        }
        else { $scope.Het = "true"; }
        console.log("So Luong:"); console.log($rootScope.SL);
        console.log("Thanh Tien:"); console.log($rootScope.TT);
    }, function error(e) { alert("Gio Hang loi"); });
    $rootScope.CheckLogin = function () {
        $http.get('/DatHang/ReadCustomer ').then(
            function (d) {
                if (d.data.login == "1") {
                    $rootScope.DangNhap = "";
                    $rootScope.KhachHang = d.data.Khach;
                    console.log(JSON.stringify($rootScope.Khach));
                    $http.get('/GioHang/GetCarts').then(function (d) {
                        $rootScope.dsDonHang = d.data.DSDonHang;
                        $rootScope.SoLuong = d.data.SoLuong;
                        $rootScope.ThanhTien = d.data.ThanhTien;
                        $window.location.href = '/DatHang/Index';

                    }, function (e) { });                
                }
                else {
                    $rootScope.DangNhap = '#myModal';

                }



            }, function () {
                alert("Customer lỗi");
            })


    };
}, function () { alert("Lỗi"); });

// Giỏ hàng
//homeapp.controller("GioHangController", function ($rootScope, $htpp) {
//    $rootScope.AddCart = function (s) {
//        $http({
//            method: 'post',
//            datatype: 'json',
//            url: '/GioHang/AddCart',
//        }).then(function success(data) {
//            $rootScope.dsDonHang = data.data.dsDonHang;
//            $rootScope.SL = data.data.SoLuong;
//            $rootScope.TT = data.data.ThanhTien;
//            console.log("So Luong:"); console.log($rootScope.SL);
//            console.log("Thanh Tien:"); console.log($rootScope.TT);
//        }, function error(e) { alert("Gio Hang loi"); });
//    }, function () { alert("Lỗi"); }
//});


homeapp.controller('LoginController', function ($scope, $rootScope, $http, $window) {
    $scope.isLoginSubmit = true

    $scope.loginSubmit = function () {
        $http({
            method: 'get',
            url: '/Login/Login',
            params: { accountname: $scope.EmailLogin, password: $scope.PassLogin }
        }).then(function (res) {
            if (res.data.login == "1") {
                $window.location.reload();
            } else {
                $scope.isLoginSubmit = false
            }
        }, function (err) {
            alert('Failed to get Account!')
        })
    }

    $scope.Logout = function () {
        $http({
            method: 'get',
            url: '/Login/Logout'
        }).then(function (res) {
            if (res.data.login == "0") {
                $window.location.reload();
            } else {
                alert('Failed to logout!')
            }
        }, function (err) {
            alert('Failed to logout!')
        })
    }


    //let sidebarSetting = document.querySelector('.sidebar__setting')
    //document.body.addEventListener('click', function (e) {
    //    if (e.target.closest('.sidebar__setting') == null && e.target.closest('.sidebar__btn-setting') == null) {
    //        sidebarSetting.classList.remove('show')
    //    }
    //    if (e.target.closest('.sidebar__btn-setting')) {
    //        sidebarSetting.classList.toggle('show')
    //    }
    //})
})
//homeapp.controller("LoginController", function ($rootScope, $scope, $http) {
//    $rootScope.close = "";
//    $rootScope.Khach = null;
//    $rootScope.login = 0;
//    $rootScope.image = "";
//    $rootScope.remember = false;
//    $rootScope.Logout = function () {
//        $http.get("/Home/Logout").then(function (d) {
//            $rootScope.Log = "Login";
//        }, function () { });
//    };
//    $rootScope.Login = function (un, pw, rp) {
//        $http.get("Home/Login", {
//            params: {
//                us: un,
//                pw: pw,
//                rp: rp
//            }
//        }).then(function (d) {
//            if (d.data.login == 0) {
//                alert("Dang nhap khong thanh cong");
//                $rootScope.close = "";
//            }
//            else {

//                $rootScope.close = 'modal';
//                alert("Dang nhap thanh cong");
//                $rootScope.image = 'src';
//            }
//        }, function error(e) { });
//    }
//});
homeapp.controller("LoginController", function ($rootScope, $scope, $http) {
    $rootScope.close = "";
    $rootScope.Khach = null;
    $rootScope.remember = false;
    $rootScope.userName = "";
    $rootScope.Logout = function () {
        document.getElementById('dropdownMenuButton').style.display = 'none';
        location.reload();
    };
    $rootScope.LInLout = function () {
        if ($rootScope.lInOut == "SignIn") {
            $rootScope.Finout = "#myModal";
        }
        else {
            $rootScope.Finout = "";
            $rootScope.Logout();
        }
    }
    $rootScope.Login = function (un, pw, rp) {
        console.log(un, pw, rp);

        $http.get("Home/Login", {

            params: {
                us: un,
                pw: pw,
                rp: rp
            }
        }).then(function (d) {
            if (d.data.login == "0") {
                $rootScope.close = '';
                $rootScope.login = d.data.login;
                alert("Dang nhap khong thanh cong");
                console.log(d);
            }
            else {
                var q = document.getElementById('logout_tk');
                q.remove();
                $rootScope.login = d.data.login;
                $rootScope.userName = d.data.Khach.UserName;

                if ($rootScope.userName == d.data.Khach.UserName) {

                }
                $rootScope.close = 'modal';

            }
        }, function error(e) { });
    }
});