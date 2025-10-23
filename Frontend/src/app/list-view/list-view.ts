import { Component, inject, OnInit } from '@angular/core';
import * as L from 'leaflet';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-list-view',
  standalone: true,
  templateUrl: './list-view.html',
  styleUrls: ['./list-view.scss'],
})
export class ListView implements OnInit {
  map!: L.Map;
  private api = inject(ApiService);

  items = this.api.alerts;

  ngOnInit(): void {
   this.api.loadAlerts();
 }

  setMap(map: L.Map) {
    this.map = map;
  }

  zoomToItem(item: any) {
    if (!this.map) return;
    this.map.setView(item.coords, 16);
    L.marker(item.coords).addTo(this.map);
  }
}
