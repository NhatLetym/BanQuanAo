
/// <reference path="../angular.min.js" />
var myapp = angular.module('AdminApp', ['ngFileUpload']);
myapp.controller("ProductController",
    function ($rootScope, $scope, $window, $http) {
        $http.get('/QLSanPham/GetCategory').then(function (d) {
            $scope.listLoai = d.data;
        }, function (error) { alert("Loi loai"); });
        $http.get('/QLSanPham/GetSanPham').then(function (d) {
            $rootScope.lsp = d.data;
        }, function (error) {
            alert('That bai');
        });
        $scope.Delete = function Xoa(s) {
            $http({
                method: "Post",
                url: "/QLSanPham/DeleteProduct",
                params: { masp: s.MaSP }
            }).then(function Success(d) {
                var vt = $scope.lsp.indexOf(s);
                $scope.lsp.splice(vt, 1);
            }, function error(e) {
                alert("Lấy sản phẩm lỗi");
            });
        }

        $scope.Edit = function (s) {
            $scope.lsp = s;
        }

        $scope.Add = function () {
            $scope.lsp = null;
        }
        $scope.SaveAdd = function () {
            $http({
                method: 'Post',
                url: '/QLSanPham/AddProduct',
                datatype: 'Json',
                params: { s: $scope.lsp }
            }).then(function (d) {
                if (d.data == "") {
                    $scope.lsp.push($scope.sp);
                    $scope.sp = null;
                    alert("Data Submitted....!");
                }
                else {
                    alert(d.data);
                }
            }, function () {
                alert("Save new records Error");
            });
        }
        $scope.SaveEdit = function () {
            $http({
                method: 'Post',
                url: '/QLSanPham/EditProduct',
                datatype: 'Json',
                params: { s: $scope.lsp }
            }).then(function (d) {
                if (d.data == "") {
                    alert("Data Editted....!")
                }
                else {
                    alert(d.data);
                }
            }, function () {
                alert("Edit records Error");
            });
        }
    });
myapp.controller("SanPhamController", function ($scope, $http) {
    var maloai = localStorage.getItem("MaLoai") //;
    $http({
        method: "get",
        url: '/SanPham/GetSanPhamTheoLoai',
        params: { MaLoai: maloai }
    }).then(function success(d) {
        $scope.ListSanPham = d.data;
    }, function error(e) { alert("Error") });
    $rootScope.AddCart = function (s) {
        $http({
            method: 'post',
            datatype: 'json',
            url: '/GioHang/AddCart',
        }).then(function success(data) {
            $rootScope.dsDonHang = data.data.dsDonHang;
            $rootScope.SL = data.data.SoLuong;
            $rootScope.TT = data.data.ThanhTien;
            console.log("So Luong:"); console.log($rootScope.SL);
            console.log("Thanh Tien:"); console.log($rootScope.TT);
        }, function error(e) { alert("Gio Hang loi"); });
    }, function () { alert("Lỗi"); }

});
myapp.controller("UploadController", function ($scope, Upload, $http, $document) {
    //Lấy về loại sản phẩm
    //Begin Upload file
    $scope.UploadFiles = function (file) {
        $scope.SelectedFiles = file;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/QLSanPham/Upload',
                data: { maloai: $scope.sanpham.MaLoai, files: $scope.SelectedFiles }
            }).then(function (d) {
                $scope.sp.Anh = d.data[0];
                $scope.sp.AnhTo = d.data[1];
            }, function (error) { alert('lỗi'); });
        }
    }//end upload file
});


