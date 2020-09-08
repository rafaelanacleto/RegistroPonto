import { Component, OnInit } from '@angular/core';
import { Ponto } from '../_models/Ponto';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { templateJitUrl } from '@angular/compiler';
import { ToastrService } from 'ngx-toastr';
import { PontoService } from "../_services/ponto.service";

defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-ponto',
  templateUrl: './ponto.component.html',
  styleUrls: ['./ponto.component.css']
})
export class PontoComponent implements OnInit {

  pontos: Ponto[];
  ponto: Ponto;
  _filtroList: string;
  pontoFiltrados: Ponto[];
  eventosFiltrados: Ponto[];
  registerForm: FormGroup;
  dataAtual: string;
  pontoInserir: Ponto;
  bodyDeletarEvento = '';

  constructor( private modalService: BsModalService,
    private pontoService: PontoService,
    private fb: FormBuilder,
    private local: BsLocaleService,
    private toastr: ToastrService) {
      this.local.use('pt-br');
     }

  ngOnInit(): void {
    this.validation();
    this.getPontos();
  }

  getPontos() {
    this.dataAtual = new Date().getMilliseconds().toString();

    this.pontoService.getAllPonto().subscribe(
      (_ponto: Ponto[]) => {
        this.pontos = _ponto;
        this.eventosFiltrados = this.pontos;       
      }, error => {
        this.toastr.error(`Erro ao tentar Carregar registro de Pontos: ${error}`);
      });
  }

  get filtroLista(): string {
    return this._filtroList;
  }

  set filtroLista(value: string) {
    this._filtroList = value;
    this.pontoFiltrados = this._filtroList ? this.filtrarEvento(this.filtroLista) : this.pontos;
  }

  filtrarEvento(filtrarPor: string): Ponto[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.pontos.filter(
      ponto => ponto.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  novoEvento(template: any) {
    this.openModal(template);  

  }

  openModal(template: any) {
    this.registerForm.reset();    
    template.show();
  }

  validation() {
    this.registerForm = this.fb.group({      
      nome: ['', Validators.required],
      registro: ['', Validators.required],
      entradaSaida: ['', Validators.required]
    });
  }
  
  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {     
        this.pontoInserir = Object.assign({}, this.registerForm.value);

        this.pontoService.postPonto(this.pontoInserir).subscribe(
          (novoEvento: Ponto) => {
            template.hide();
            this.getPontos();
            this.toastr.success('Inserido com Sucesso!');
          }, error => {
            this.toastr.error(`Erro ao Inserir: ${error}`);
          }
        );
     
    }
  }

  confirmeDelete(template: any) {
    this.pontoService.deletePonto(this.ponto.id).subscribe(
      () => {
        template.hide();
        this.getPontos();
        this.toastr.success('Deletado com Sucesso');
      }, error => {
        this.toastr.error('Erro ao tentar Deletar');
        console.log(error);
      }
    );
  }

  excluirEvento(ponto: Ponto, template: any) {
    this.openModal(template);
    this.ponto = ponto;
    this.bodyDeletarEvento = `Tem certeza que deseja excluir o Evento: ${ponto.nome}, ID: ${ponto.id}`;
  }


}
