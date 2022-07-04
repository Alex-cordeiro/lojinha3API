import { Desenvolvedora } from "./Desenvolvedora.model";
import { Plataforma } from "./plataforma.model";

export class Jogo{
    id!: number;
    titulo!: string;
    anoLancamento!: number;
    idDesenvolvedora!: number;
    idPlataforma!: number;
    plataforma!: Array<Plataforma>;
    desenvolvedora!: Array<Desenvolvedora>;
}