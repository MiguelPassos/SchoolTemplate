﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $(".alert").delay(1000).slideDown(200).delay(4000).slideUp(200, function () {
        //$(this).alert('close');
    });
});