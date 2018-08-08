// define placement, sitewide
var network = 8691100,
	bsa_debug = true,
	bsa_targeting = [
		['bsas2s', 'true'],
		['bsas2spub', 'sitepoint']
	],
	placements = {
		"bsa-zone_1509641776795-0_123456": 
		{
			"id": "bsa-zone_1509641776795-0_123456",
			"name": "SitePoint_200x125_ArticlesBar1_Top_Articles",
			"sizes": [200, 125],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[200, 125]]
					]
				]
			}
		},
		"bsa-zone_1509641776795-1_123456": 
		{
			"id": "bsa-zone_1509641776795-1_123456",
			"name": "SitePoint_200x125_ArticlesBar2_Mid_Articles",
			"sizes": [200, 125],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[200, 125]]
					]
				]
			}
		},
		"bsa-zone_1509641776795-2_123456": 
		{
			"id": "bsa-zone_1509641776795-2_123456",
			"name": "SitePoint_200x125_ArticlesBar3_Bottom_Articles",
			"sizes": [200, 125],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[200, 125]]
					]
				]
			}
		},
		"bsa-zone_1509641776795-3_123456": 
		{
			"id": "bsa-zone_1509641776795-3_123456",
			"name": "SitePoint_300x250_ArticlesMedRec_Side_Articles",
			"sizes": [300, 250],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[300, 250]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-4_123456": 
		{
			"id": "bsa-zone_1509641776795-4_123456",
			"name": "SitePoint_300x600_ArticlesHalfPage_Side_Articles",
			"sizes": [[300, 600], [160, 600], [300, 250]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[300, 600], [160, 600], [300, 250]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-5_123456": 
		{
			"id": "bsa-zone_1509641776795-5_123456",
			"name": "SitePoint_300x600_HomeHalfPage_Side_Home",
			"sizes": [[300, 600], [160, 600], [300, 250]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[300, 600], [160, 600], [300, 250]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-6_123456": 
		{
			"id": "bsa-zone_1509641776795-6_123456",
			"name": "SitePoint_728x90_ArticlesLeaderboard_Content_Articles",
			"sizes": [[970, 250], [970, 90], [728, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[728, 90]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-7_123456": 
		{
			"id": "bsa-zone_1509641776795-7_123456",
			"name": "SitePoint_728x90_ArticlesLeaderboard2_ContentMid_Articles",
			"sizes": [[728, 90], [970, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[728, 90], [970, 90]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-8_123456": 
		{
			"id": "bsa-zone_1509641776795-8_123456",
			"name": "SitePoint_970x250_ChannelLeaderboard1_Upper_Channel",
			"sizes": [[970, 90], [970, 250], [728, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[970, 90], [970, 250], [728, 90]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-9_123456": 
		{
			"id": "bsa-zone_1509641776795-9_123456",
			"name": "SitePoint_970x250_ChannelLeaderboard2_Mid_Channel",
			"sizes": [[970, 250], [970, 90], [728, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[728, 90]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-10_123456": 
		{
			"id": "bsa-zone_1509641776795-10_123456",
			"name": "SitePoint_970x250_ChannelLeaderboard3_LowerMid_Channel",
			"sizes": [[970, 90], [970, 250], [728, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[970, 90], [970, 250], [728, 90]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-11_123456": 
		{
			"id": "bsa-zone_1509641776795-11_123456",
			"name": "SitePoint_970x250_ChannelLeaderboard4_Lower_Channel",
			"sizes": [[970, 90], [970, 250], [728, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[970, 90], [970, 250], [728, 90]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-12_123456": 
		{
			"id": "bsa-zone_1509641776795-12_123456",
			"name": "SitePoint_970x250_HomeLeaderboard1_Top_Home",
			"sizes": [[970, 90], [970, 250], [728, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[970, 90], [970, 250], [728, 90]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-13_123456": 
		{
			"id": "bsa-zone_1509641776795-13_123456",
			"name": "SitePoint_970x250_HomeLeaderboard2_Mid_Home",
			"sizes": [[970, 90], [970, 250], [728, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[970, 90], [970, 250], [728, 90]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-14_123456": 
		{
			"id": "bsa-zone_1509641776795-14_123456",
			"name": "SitePoint_970x250_HomeLeaderboard3_Lower_Home",
			"sizes": [[970, 90], [970, 250], [728, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[970, 90], [970, 250], [728, 90]]
					]
				]
			}
		},
		// TODO: sizemapping
		"bsa-zone_1509641776795-15_123456": 
		{
			"id": "bsa-zone_1509641776795-15_123456",
			"name": "SitePoint_970x90_ForumsLeaderboard_Top_Forums",
			"sizes": [[728, 90], [970, 90]],
			"options": {
				"sizemap": [
					[
						[0, 0],
						[[728, 90], [970, 90]]
					]
				]
			}
		}
	};

// setup purch & gpt
var purchs2s = purchs2s || {};
	purchs2s.cmd = purchs2s.cmd || [];
	purchs2s.timeout = 1000;
var googletag = googletag || {};
	googletag.cmd = googletag.cmd || [];
(
	function() {
		//purch
		var ps2s = document.createElement('script');
			ps2s.async = true;
			ps2s.type = 'text/javascript';
			ps2s.src = '//ads.servebom.com/purchs2s.js';
		document.getElementsByTagName('head')[0].appendChild(ps2s);
		
		// gpt
		var gads = document.createElement('script');
			gads.async = true;
			gads.type = 'text/javascript';
			gads.src = '//www.googletagservices.com/tag/js/gpt.js';
		document.getElementsByTagName('head')[0].appendChild(gads);
	}
)();

/*!
  * domready (c) Dustin Diaz 2012 - License MIT
  */
!function (name, definition) {
  if (typeof module != 'undefined') module.exports = definition()
  else if (typeof define == 'function' && typeof define.amd == 'object') define(definition)
  else this[name] = definition()
}('domready', function (ready) {

  var fns = [], fn, f = false
    , doc = document
    , testEl = doc.documentElement
    , hack = testEl.doScroll
    , domContentLoaded = 'DOMContentLoaded'
    , addEventListener = 'addEventListener'
    , onreadystatechange = 'onreadystatechange'
    , readyState = 'readyState'
    , loadedRgx = hack ? /^loaded|^c/ : /^loaded|c/
    , loaded = loadedRgx.test(doc[readyState])

  function flush(f) {
    loaded = 1
    while (f = fns.shift()) f()
  }

  doc[addEventListener] && doc[addEventListener](domContentLoaded, fn = function () {
    doc.removeEventListener(domContentLoaded, fn, f)
    flush()
  }, f)


  hack && doc.attachEvent(onreadystatechange, fn = function () {
    if (/^c/.test(doc[readyState])) {
      doc.detachEvent(onreadystatechange, fn)
      flush()
    }
  })

  return (ready = hack ?
    function (fn) {
      self != top ?
        loaded ? fn() : fns.push(fn) :
        function () {
          try {
            testEl.doScroll('left')
          } catch (e) {
            return setTimeout(function() { ready(fn) }, 50)
          }
          fn()
        }()
    } :
    function (fn) {
      loaded ? fn() : fns.push(fn)
    })
});

domready(
	function () {
	
		googletag.cmd.push(
			function() {
				purchs2s.cmd.push(
					function() {
						for (var i = 0, ps = document.querySelectorAll('[id^=bsa-zone_]'); i < ps.length; i++)
							if(typeof placements[ps[i].id] != 'undefined')
								window.googletag.defineSlot('/' + network + '/' + placements[ps[i].id].name, placements[ps[i].id].sizes, ps[i].id)
									.defineSizeMapping(
										purchs2s.sizeMapping(placements[ps[i].id].id)
											.addSize(placements[ps[i].id].options.sizemap[0][0], placements[ps[i].id].options.sizemap[0][1])
											.build()
									)
									.addService(googletag.pubads());
						
						for (var i = 0; i < bsa_targeting.length; i++)
							googletag.pubads().setTargeting(bsa_targeting[i][0], bsa_targeting[i][1]);
						
						googletag.pubads().enableSingleRequest();
						
						if(!bsa_debug)
							googletag.pubads().collapseEmptyDivs();
						
						googletag.pubads().disableInitialLoad();
						googletag.enableServices();
						purchs2s.setup();
					}
				);
		 	}
		);
		
		// initiate the slots here vs. inline on the page
		window.googletag.cmd.push(
			function(){
				for (var i = 0, ps = document.querySelectorAll('[id^=bsa-zone_]'); i < ps.length; i++)
					if(typeof placements[ps[i].id] != 'undefined')
						window.googletag.display(ps[i].id);
			}
		);
		
	}
);

// debug / friendly output for console for now
if(bsa_debug) {
	window.googletag.cmd.push(
		function() {
			var output = [];
		    window.googletag.pubads().getSlots().forEach(function (slot) {
		        var s = slot.getSizes();
		        var sizeArray = [];
		        var s2 = "";
		        for ( var i = 0; i < s.length; i++){
		            s2 += s[i].l+"x"+s[i].j+",";
		        }
		        output.push({
		            'adunitPath' : slot.getName(),
		            'TargetingMap': JSON.stringify(slot.getTargetingMap()),
		            'div' : slot.getSlotElementId(),
		            "size" : s2,
		        });
		    });
		    if (output.length) {
		        if (console.table) {
		            console.table(output);
		        } else {
		            for (var j = 0; j < output.length; j++) {
		                console.log(output[j]);
		            }
		        }
		    } else {
		        console.warn('No defined slots');
		    }
	    }
    );
}