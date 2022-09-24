import { Button } from "react-bootstrap";
import styled from "styled-components";

export const DivAmarela = styled.div`
    background-color: yellow;
`

export const ButaoRosa = styled(Button)`
    background-color: ${({theme}) => theme.colors.primary.main};
`