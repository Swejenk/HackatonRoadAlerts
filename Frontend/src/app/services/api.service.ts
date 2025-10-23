import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { toSignal } from '@angular/core/rxjs-interop';

export interface VehicleStopped {
  vin: string;
  lat: number;
  lon: number;
  registeredAt: string;
  heading: number;
}

export interface ListItem {
  title: string;
  description: string;
  coords: [number, number];
}

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private http = inject(HttpClient);
  private baseUrl = 'https://localhost:7269'; 

  // Om du vill exponera datan som en signal:
  alerts = signal<any[]>([]);

  constructor() {
    this.loadAlerts();
  }

  loadAlerts() {
    this.http.get<VehicleStopped[]>(`${this.baseUrl}/vehicles/stopped`).subscribe({
      next: (data) => {
        // Mappa API-datat till ListView-format
        const mapped = data.map((v) => ({
          title: `Vehicle ${v.vin}`,
          description: `Registered: ${new Date(v.registeredAt).toLocaleString()}`,
          coords: [v.lat, v.lon] as [number, number],
        }));
        this.alerts.set(mapped);
      },
      error: (err) => console.error('API Error:', err),
    });
  }

  // Alternativt, Observable-version
  getAlerts$() {
    return this.http.get<VehicleStopped[]>(`${this.baseUrl}/vehicles/stopped`);
  }
}