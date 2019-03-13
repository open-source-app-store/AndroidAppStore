/**
 *  Document   : material-loading.js
 *  Author     : redstar
 *  Description: script for material design loading page 
 *
 **/

document.querySelector('#p1').addEventListener('mdl-componentupgraded', function() {
	this.MaterialProgress.setProgress(44);
});

document.querySelector('#p3').addEventListener('mdl-componentupgraded', function() {
	this.MaterialProgress.setProgress(33);
	this.MaterialProgress.setBuffer(87);
});