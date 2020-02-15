import { Persona,Departamento } from './model.index';


export class Usuario {

    constructor(
        public usuario_Id: number,
        public nombre: string,
        public rol:number,
        public password: string,
        public persona:Persona,
        public departamento:Departamento

    ) { }

}