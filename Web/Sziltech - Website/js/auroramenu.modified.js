var _____WB$wombat$assign$function_____ = function(name) {return (self._wb_wombat && self._wb_wombat.local_init && self._wb_wombat.local_init(name)) || self[name]; };
if (!self.__WB_pmw) { self.__WB_pmw = function(obj) { this.__WB_source = obj; return this; } }
{
  let window = _____WB$wombat$assign$function_____("window");
  let self = _____WB$wombat$assign$function_____("self");
  let document = _____WB$wombat$assign$function_____("document");
  let location = _____WB$wombat$assign$function_____("location");
  let top = _____WB$wombat$assign$function_____("top");
  let parent = _____WB$wombat$assign$function_____("parent");
  let frames = _____WB$wombat$assign$function_____("frames");
  let opener = _____WB$wombat$assign$function_____("opener");

// Aurora Menu v1.0
// Design and conception by Aurora Studio http://www.aurora-studio.co.uk
// Plugin development by Invent Partners http://www.inventpartners.com
// Copyright Invent Partners & Aurora Studio 2009

var auroraMenuSpeed = 150;

$(document).ready(function(){
	$.cookie('testcookie' , 'expanded', {path:'/'})
	var auroramenucount = 0;
	$('.auroramenu').each(function(){
		var auroramenuitemcount = 0;
		$(this).children('li').children('ul').each(function(){
			if($.cookie('arMenu_' + auroramenucount + '_arItem_' + auroramenuitemcount) == 1){
				$(this).siblings('a').attr('onClick' , 'auroraMenuItem(\'' + auroramenucount + '\' , \'' + auroramenuitemcount + '\' , \'0\'); return false;');
				$(this).parent().children('.aurorahide').css("display","inline");
				$(this).parent().children('.aurorashow').css("display","none");
			} else {
				$(this).css("display","none");
				$(this).siblings('a').attr('onClick' , 'auroraMenuItem(\'' + auroramenucount + '\' , \'' + auroramenuitemcount + '\' , \'1\'); return false;');
				$(this).parent().children('.aurorahide').css("display","none");
				$(this).parent().children('.aurorashow').css("display","inline");
			}
			auroramenuitemcount ++;
		});
		auroramenucount ++;
	});
});





function auroraMenuItem(menu , item , show){
   $.cookie('arMenu_' + menu + '_arItem_' + item , show, {path:'/'});
	var auroramenucount = 0;
	$('.auroramenu').each(function(){
		if(menu == auroramenucount){
			var auroramenuitemcount = 0;
			$(this).children('li').children('ul').each(function(){
				if(item == auroramenuitemcount){
					if(show == 1){
						$(this).slideDown(auroraMenuSpeed);
						//$(this).click(auroraMenuItemHide(menu , item));
						$(this).siblings('a').attr('onClick' , 'auroraMenuItem(\'' + menu + '\' , \'' + item + '\' , \'0\'); return false;');
						$(this).parent().children('.aurorahide').css("display","inline");
						$(this).parent().children('.aurorashow').css("display","none");

					} else {
						$(this).slideUp(auroraMenuSpeed);
						$(this).siblings('a').attr('onClick' , 'auroraMenuItem(\'' + menu + '\' , \'' + item + '\' , \'1\'); return false;');
						$(this).parent().children('.aurorahide').css("display","none");
						$(this).parent().children('.aurorashow').css("display","inline");

					}
				}else{

						$(this).slideUp(auroraMenuSpeed);
						$(this).siblings('a').attr('onClick' , 'auroraMenuItem(\'' + menu + '\' , \'' + auroramenuitemcount + '\' , \'1\'); return false;');
						$(this).parent().children('.aurorahide').css("display","none");
						$(this).parent().children('.aurorashow').css("display","inline");
				$.cookie('arMenu_' + menu + '_arItem_' + auroramenuitemcount , '0' , {path:'/'});
				}

				auroramenuitemcount ++;
			});
		}
		auroramenucount ++;
	});
}

}
/*
     FILE ARCHIVED ON 20:44:51 Jan 20, 2015 AND RETRIEVED FROM THE
     INTERNET ARCHIVE ON 17:56:53 May 21, 2025.
     JAVASCRIPT APPENDED BY WAYBACK MACHINE, COPYRIGHT INTERNET ARCHIVE.

     ALL OTHER CONTENT MAY ALSO BE PROTECTED BY COPYRIGHT (17 U.S.C.
     SECTION 108(a)(3)).
*/
/*
playback timings (ms):
  captures_list: 0.57
  exclusion.robots: 0.022
  exclusion.robots.policy: 0.01
  esindex: 0.014
  cdx.remote: 10.647
  LoadShardBlock: 261.006 (3)
  PetaboxLoader3.datanode: 95.815 (4)
  PetaboxLoader3.resolve: 134.37 (2)
  load_resource: 214.519
*/