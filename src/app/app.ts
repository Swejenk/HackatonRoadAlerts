import { Component, AfterViewInit, ViewChild } from '@angular/core';
import * as L from 'leaflet';
import { ListView } from './list-view/list-view';
import OsmStreetview from './osm-streetview/osm-streetview';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.scss'],
  standalone: true,
  imports: [ListView],
})
export class App implements AfterViewInit {
  map!: L.Map;

  @ViewChild(ListView) listView!: ListView;
  @ViewChild(OsmStreetview) osmStreetview!: OsmStreetview;

  ngAfterViewInit(): void {
    // create the map
    this.map = L.map('map').setView([59.3293, 18.0686], 13); // Stockholm

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      attribution: '&copy; OpenStreetMap contributors',
    }).addTo(this.map);

    // pass the map reference to the list so it can zoom
    if (this.listView) {
      this.listView.setMap(this.map);
    }

    // optional: pass to OsmStreetview if you want
    if (this.osmStreetview) {
      this.osmStreetview.map = this.map;
    }
  }
}
