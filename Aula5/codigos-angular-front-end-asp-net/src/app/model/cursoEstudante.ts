import { Curso } from "./curso";
import { Estudante } from "./estudante";

export interface cursoEstudante extends Curso {
    // cursoId: number,
    // cursoMensalidade: number,
    // cursoNome: string,
    estudante: Estudante,
    // estudanteId: number,
    // estudanteRa: number
}