import { Component, AfterViewInit } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-osm-streetview',
  standalone: true,
  templateUrl: './osm-streetview.html', // no ".component" in modern naming
  styleUrls: ['./osm-streetview.scss'],
})
export default class OsmStreetview implements AfterViewInit {
  map!: L.Map;

  ngAfterViewInit(): void {
    this.map = L.map('map').setView([59.3293, 18.0686], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      attribution: '&copy; OpenStreetMap contributors',
    }).addTo(this.map);
  }

  // helper method so other components can zoom/pan
  zoomTo(coords: [number, number], zoom: number = 16) {
    if (this.map) {
      this.map.setView(coords, zoom);
      L.marker(coords).addTo(this.map); // optional
    }
  }
}
