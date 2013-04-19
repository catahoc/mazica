$(function () {
	
	//setup render context
	var renderContext = document.getElementById("RenderContext");
	
	var w = document.body.clientWidth;
	var h = document.body.clientHeight;

	//setup camera
	var camera = new THREE.PerspectiveCamera(45, w / h, 1, 10000);
	camera.position.z = 4300;

	//setup sun
	var sunGeom = new THREE.SphereGeometry(430, 30, 30);
	var sunMat = new THREE.MeshNormalMaterial();
	var sun = new THREE.Mesh(sunGeom, sunMat);

	//create scene with sun
	var scene = new THREE.Scene();
	scene.add(sun);

	//setup renderer
	var renderer = new THREE.CanvasRenderer();
	renderer.setSize(w, h);
	renderContext.appendChild(renderer.domElement);
	
	//frame render function
	var animate = function () {
		requestAnimationFrame(animate);
		sun.rotation.y += 0.01;
		renderer.render(scene, camera);
		console.log('render');
	};

	animate();



});