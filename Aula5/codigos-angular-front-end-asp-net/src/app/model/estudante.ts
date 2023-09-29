// esta interface tem o propósito de atuar como model domain para a aplicação 

export interface Estudante {
    //definir as props que serão utilizadas como "conjunto de regras" para a manipulação de dados
    Estudante_Id: number
    Estudante_Nome: string
    Estudante_Sobrenome: string
    Estudante_RA: number;
    Estudante_Email: string;
    Estudante_Idade: number;
    Estudante_Fone: string;
    Estudante_Genero: string
}
