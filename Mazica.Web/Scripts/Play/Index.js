$(function () {
	var cubeSize = 10;
	var cubeDistance = 100;
	var hasRotationalContext = false;
	var cameraRelLookPos;
	$.getJSON("/Play/GetMaze", function (jsonMaze) {
		
		//setup render context
		var renderContext = document.getElementById("RenderContext");

		var widthOfRenderCtx = document.body.clientWidth;
		var heightOfRenderCtx = document.body.clientHeight;

		//setup camera
		var camera = new THREE.PerspectiveCamera(45, widthOfRenderCtx / heightOfRenderCtx, 1, 10000);
		cameraRelLookPos = new THREE.Vector3(0, 0, 100);
		camera.lookAt(camera.position)

		//create scene
		var scene = new THREE.Scene();

		//setup renderer
		var renderer = new THREE.CanvasRenderer();
		renderer.setSize(widthOfRenderCtx, heightOfRenderCtx);
		renderContext.appendChild(renderer.domElement);
		
		//data
		var blockMeshes = new Array();
		var data = jsonMaze.Matrix;
		var mw = jsonMaze.Width;
		var mh = jsonMaze.Height;
		var md = jsonMaze.Depth;
		for (var w = 0; w < mw; ++w) {
			for (var h = 0; h < mh; ++h) {
				for (var d = 0; d < md; ++d) {
					var geom = new THREE.CubeGeometry(cubeSize, cubeSize, cubeSize);
					var mat = new THREE.MeshNormalMaterial();
					var mesh = new THREE.Mesh(geom, mat);
					mesh.position.x = (w - mw / 2) * cubeDistance;
					mesh.position.y = (h - mh / 2) * cubeDistance;
					mesh.position.z = (d - md / 2) * cubeDistance;
					blockMeshes.push(mesh);
					scene.add(mesh);
				}
			}
		}

		$('body').keydown(function(e) {
			var forward = 87; //w
			var backward = 83; //s
			var strafeLeft = 65; //a
			var strafeRight = 68; //d
			var upper = 38; //up arrow
			var lower = 40; //down arrow
			if (e.keyCode == 17) {
				hasRotationalContext = !hasRotationalContext;
			}
			switch (e.keyCode) {
				case forward:
					camera.position.z += 10;
					break;
				case backward:
					camera.position.z -= 10;
					break;
				case strafeRight:
					camera.position.x += 10;
					break;
				case strafeLeft:
					camera.position.x -= 10;
					break;
				case upper:
					camera.position.y += 10;
					break;
				case lower:
					camera.position.y -= 10;
					break;
			}
			console.log('lol');
		}).mousemove(function(mm) {
			var dx = event.pageXOffset;
			var dy = event.pageYOffset;
			var cameraPosition = camera.position;
			var lookPosition = camera.direction;
		});

		//frame render function
		var animate = function() {
			requestAnimationFrame(animate);
			renderer.render(scene, camera);
		};

		animate();
	});
});