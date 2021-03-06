﻿using System.Web.Optimization;

namespace MVC_5_BlogTamplate
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            

            bundles.Add(new ScriptBundle("~/bundles/underscore").Include(
                "~/Scripts/underscore-min.js"));


            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/homeindex").Include(
                "~/Scripts/HomeJs/goingjs.js",
                "~/Scripts/HomeJs/followjs.js",
                "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/bootbox.min.js",
                "~/Scripts/jquery-{version}.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.min.css",
                "~/Content/toastr.css"));
        }
    }
}