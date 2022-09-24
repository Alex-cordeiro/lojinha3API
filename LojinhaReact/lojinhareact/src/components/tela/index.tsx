import { CustomNavbar } from "../navbar";

export function Tela({children}){
    return(
        <div>
            <CustomNavbar/>
            {children}
        </div>
    )
}