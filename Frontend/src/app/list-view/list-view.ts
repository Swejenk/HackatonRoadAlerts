import { Component } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-list-view',
  standalone: true,
  templateUrl: './list-view.html',
  styleUrls: ['./list-view.scss'],
})
export class ListView {
  map!: L.Map;

  items = [
    { title: 'Accident', description: 'Item 1', coords: [59.3293, 18.0686] },
    { title: 'Rainy day', description: 'Item 2', coords: [59.332, 18.064] },
    { title: 'Roadblock', description: 'Item 3', coords: [59.327, 18.07] },
    { title: 'Construction', description: 'Item 4', coords: [59.331, 18.072] },
  ];

  setMap(map: L.Map) {
    this.map = map;
  }

  zoomToItem(item: any) {
    if (!this.map) return;
    this.map.setView(item.coords, 16);
    L.marker(item.coords).addTo(this.map);
  }
}
