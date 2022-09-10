let wavesurfer;

export function init() {
    wavesurfer = WaveSurfer.create({
        container: document.querySelector('#waveform'),
        
        barWidth: 1,
        height: 24,
        responsive: true,
        scrollParent: true,
        waveColor: '#999999',
        cursorColor: '#333333',
        hideScrollbar: true,
        normalize: true,
        minPxPerSec: 60,
        pixelRatio: 1,
        partialRenderer: true,
        progressColor: '#222222',
        mediaControls: true,
        barHeight: 24, // the height of the wave
        barGap: 0 // the optional spacing between bars of the wave, if not provided will be calculated in legacy format
    });
    wavesurfer.on('ready', function () {
        wavesurfer.play();
    });
}

export function pause() {
    wavesurfer.pause();
}

export function play(url) {
    wavesurfer.load('_content/Blazor.AdminLte.Site.Shared/audio/Sjef van Leeuwen - Acid Ocean.mp3');
}