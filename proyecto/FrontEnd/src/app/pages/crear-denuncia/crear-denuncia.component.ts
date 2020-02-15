import { Component, OnInit, ViewChild, ElementRef  } from '@angular/core';

@Component({
  selector: 'app-crear-denuncia',
  templateUrl: './crear-denuncia.component.html',
  styles: []
})
export class CrearDenunciaComponent implements OnInit {

  map: google.maps.Map;
  lat = 40.73061;
  lng = -73.935242;
  @ViewChild('mapContainer', { static: false }) gmap: ElementRef;
  
  constructor() { }

  ngOnInit() {
    this.mapInitializer();
    this.gmap.nativeElement = new Map()
  }

  coordinates = new google.maps.LatLng(this.lat, this.lng);

  mapOptions: google.maps.MapOptions = {
    center: this.coordinates,
    zoom: 8
  };

  marker = new google.maps.Marker({
    position: this.coordinates,
    map: this.map,
    title: 'Hello World!'
  });

  mapInitializer() {
    this.map = new google.maps.Map(this.gmap.nativeElement, this.mapOptions);
    this.marker.setMap(this.map);
  }


}
