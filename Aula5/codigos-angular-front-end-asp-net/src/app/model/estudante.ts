// esta interface tem o propósito de atuar como model domain para a aplicação 

import { Curso } from "./curso";

export interface Estudante {
    //definir as props que serão utilizadas como "conjunto de regras" para a manipulação de dados
    estudanteId: number
    estudanteNome: string
    estudanteSobrenome: string
    estudanteRA: number;
    estudanteEmail: string;
    estudanteIdade: number;
    estudanteFone: string;
    estudanteGenero: string;
}
