var mapMain;


// @formatter:off 
require([
    "esri/map",
    "esri/geometry/Extent",
    "esri/layers/ArcGISDynamicMapServiceLayer",
    "esri/layers/FeatureLayer",
    "esri/dijit/BasemapGallery",
    "esri/dijit/Legend",
    "dojo/ready",
    "dojo/parser",
    "dojo/on",
    "dijit/layout/BorderContainer",
    "dijit/layout/ContentPane",
    "esri/layers/FeatureLayer",
    "esri/dijit/Legend",
    "esri/dijit/BasemapGallery",
    "esri/dijit/Search",
    "esri/dijit/Scalebar"],
    function (Map, Extent, ArcGISDynamicMapServiceLayer, FeatureLayer,
        BasemapGallery, Legend,
        ready, parser, on,
        BorderContainer, ContentPane, FeatureLayer, Legend, BasemapGallery, Search, Scalebar) {
        // @formatter:on
        // Wait until DOM is ready *and* all outstanding require() calls have been 
      
        ready(function () {

            // Parse DOM nodes decorated with the data-dojo-type attribute 
            parser.parse();


            // Create the map 
            mapMain = new Map("cpCenter", {
                basemap: "topo",
                center: [-7.82, 33.52],
                zoom: 13

            });

            var PA = new ArcGISDynamicMapServiceLayer("http://localhost:6080/arcgis/rest/services/projProg/PA_DAR_BOUAZZA/MapServer");

            var NR = new FeatureLayer("http://localhost:6080/arcgis/rest/services/projProg/CasaNR/FeatureServer/0");

            

            mapMain.addLayers([PA,NR]);

           

            mapMain.on("layers-add-result", function () {
                var dijitLegend = new Legend({
                    map: mapMain,
                    arrangement: Legend.ALIGN_RIGHT
                }, "divLegend");
                dijitLegend.startup();
            }); 

            var basemapGallery = new BasemapGallery({
                showArcGISBasemaps: true,
                map: mapMain
            }, "basemapGallery");
            basemapGallery.startup(); 

            var s = new Search({
                map: mapMain
            }, "search");

            
            var scalebar = new Scalebar({
                map: mapMain,
                attachTo: "bottom-center"
            },"scalbar");

            scalebar.startup();









        });
    }); 