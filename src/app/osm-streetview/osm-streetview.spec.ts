import { ComponentFixture, TestBed } from '@angular/core/testing';
import OsmStreetview from './osm-streetview';

describe('OsmStreetview', () => {
  let component: OsmStreetview;
  let fixture: ComponentFixture<OsmStreetview>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OsmStreetview],
    }).compileComponents();

    fixture = TestBed.createComponent(OsmStreetview);
    component = fixture.componentInstance;

    // Make sure the template has a <div id="map"> for Leaflet
    const mapDiv = document.createElement('div');
    mapDiv.id = 'map';
    document.body.appendChild(mapDiv);

    fixture.detectChanges();
  });

  afterEach(() => {
    // clean up map div
    const mapDiv = document.getElementById('map');
    if (mapDiv) {
      mapDiv.remove();
    }
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
