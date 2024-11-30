var videoServerIpAddress = '192.168.0.134';
var videoServerUsername = 'admin';
var videoServerPassword = 'admin';
var cameraGuids = [
	'{D5A750FC-49D8-4669-881C-0937CBC756DF}',
	'{D92CEE68-31A4-4389-A86E-C75124B93761}',
	'{2E31CDBB-B743-4A41-BF17-B6F0FCDF6C8A}',
	'{E7E8481B-E3C3-464A-9E92-DD5A53056EFF}',
	'{A17F2FCC-0EAD-46AA-8D4D-2C3F0FC36EC5}',
	'{9A5E77B1-1620-4963-A143-17DFDDAB6EF7}',
	'{A050D6E0-E049-49F1-9D22-8CAD93C60DF7}',
	'{15455315-C44A-413B-95FB-984231A27BC9}',
	'{01F37EBB-3139-4397-AFCF-16BDC85DBE12}',
	'{A17F2FCC-0EAD-46AA-8D4D-2C3F0FC36EC5}',
	'{9A5E77B1-1620-4963-A143-17DFDDAB6EF7}',
	'{A050D6E0-E049-49F1-9D22-8CAD93C60DF7}',
	'{15455315-C44A-413B-95FB-984231A27BC9}',
	'{01F37EBB-3139-4397-AFCF-16BDC85DBE12}',
	'{A17F2FCC-0EAD-46AA-8D4D-2C3F0FC36EC5}',
	'{9A5E77B1-1620-4963-A143-17DFDDAB6EF7}',
	'{A050D6E0-E049-49F1-9D22-8CAD93C60DF7}',
	'{15455315-C44A-413B-95FB-984231A27BC9}',
	'{01F37EBB-3139-4397-AFCF-16BDC85DBE12}',
	'{A17F2FCC-0EAD-46AA-8D4D-2C3F0FC36EC5}',
	'{9A5E77B1-1620-4963-A143-17DFDDAB6EF7}',
	'{A050D6E0-E049-49F1-9D22-8CAD93C60DF7}',
	'{15455315-C44A-413B-95FB-984231A27BC9}',
	'{01F37EBB-3139-4397-AFCF-16BDC85DBE12}',
	'{A17F2FCC-0EAD-46AA-8D4D-2C3F0FC36EC5}'
];

cameras = {};
for (var i = 0; i < cameraGuids.length; i++) {
	cameras[i] = { ipAddress: videoServerIpAddress, cameraGuid: cameraGuids[i], username: videoServerUsername, password: videoServerPassword }
}

function connectToCamera(camera, osd, showdateTime) {
	var vpElement = document.getElementById('VideoPicture');
	if (!vpElement) {
		console.error('Element with id="VideoPicture" not found.');
		return;
	}
	var vp = vpElement.object;
	if (!vp) {
		console.error('The object property of VideoPicture is undefined.');
		return;
	}
	
	//var vp = new ActiveXObject('VIDEOCONTROL4.VideoPictureCtrl.1'); // Works only with IE
	vp.OSD = osd ?? true;
	vp.ShowDateTime = showdateTime ?? true;
	vp.Connect(camera.ipAddress, camera.cameraGuid, camera.username, camera.password);
	//vp.WaitForConnect(1000);
	//vp.Last();	
}

function fullScreen() {
	var el = document.documentElement, rfs = el.requestFullScreen || el.webkitRequestFullScreen || el.mozRequestFullScreen || el.msRequestFullScreen;
	if (rfs) {
		rfs.call(el);
	} else {
		if (window.ActiveXObject) {	
			var wscript = new ActiveXObject('WScript.Shell');
			if (wscript) {
				wscript.SendKeys('{F11}');
			}
		}
	}
}