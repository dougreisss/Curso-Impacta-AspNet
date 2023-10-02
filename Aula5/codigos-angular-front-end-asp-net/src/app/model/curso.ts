import { Estudante } from "./estudante";

export interface Curso {
    cursoId: number;
    cursoNome: string;
    cursoMensalidade: number;
    estudanteId: number;
    estudanteRA: number;
}