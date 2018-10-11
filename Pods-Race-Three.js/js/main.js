var scene = new THREE.Scene();
var aspect = window.innerWidth / window.innerHeight;
var camera = new THREE.PerspectiveCamera( 75, aspect, 0.1, 100000 );
var renderer = new THREE.WebGLRenderer();

camera.lookAt(0, 0, 0);
camera.position.set(0, 0, 50);
var controls = new THREE.OrbitControls( camera );
renderer.setSize( window.innerWidth, window.innerHeight );
document.body.appendChild( renderer.domElement );

var ambientLight = new THREE.AmbientLight( 0xb4e7f2 );
scene.add( ambientLight );
var pointLight = new THREE.PointLight( 0xb4e7f2, 0.8 );
scene.add( pointLight );

var loader = new THREE.TextureLoader();
let normalMap = loader.load( "resources/StarSparrow_Normal.png" );
let colorMap = loader.load( "resources/StarSparrow_Red.png" );
let specMap = loader.load( "resources/StarSparrow_Emission.png" );

var geometry = new THREE.PlaneGeometry( 500, 500, 32 );
var material = new THREE.MeshBasicMaterial( {color: 0x585994, side: THREE.DoubleSide} );
var plane = new THREE.Mesh( geometry, material );
plane.position.set( 0, -10, 0 );
plane.rotation.set( THREE.Math.degToRad(90), 0, 0 );
scene.add( plane );

var render = function () {
    requestAnimationFrame( render );
    controls.update();

    renderer.render( scene, camera );
};

render();