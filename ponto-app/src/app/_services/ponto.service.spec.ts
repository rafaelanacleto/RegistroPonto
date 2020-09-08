/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PontoService } from './ponto.service';

describe('Service: Ponto', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PontoService]
    });
  });

  it('should ...', inject([PontoService], (service: PontoService) => {
    expect(service).toBeTruthy();
  }));
});
