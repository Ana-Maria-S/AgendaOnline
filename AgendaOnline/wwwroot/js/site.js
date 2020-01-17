

function sorteazaTabel(id, n) {
    var   i, x, y = 0;
    var tabelDeSortat = document.getElementById(id);
    //Initial directia de sortare: ascendent
    var directie = "ascendenta";
    var notSorted = true;
    var inregistrari = tabelDeSortat.rows;
    var interschimbareNecesara = false;
    var nrInterschimbari = 0;

    while (notSorted) {
        
        /*Loop prin toate inregistrarile*/
        for (i = 1; i < (inregistrari.length - 1); i++) {

            /*Se compara elementul curent cu urmatorul*/
            x = inregistrari[i].getElementsByTagName("TD")[n];
            y = inregistrari[i + 1].getElementsByTagName("TD")[n];

            if (directie == "ascendenta") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    interschimbareNecesara = true;
                    break;
                }
            } else if (directie == "descendenta") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    interschimbareNecesara = true;
                    break;
                }
            }
        }
        if (interschimbareNecesara) {
            /*Daca a fost nevoie de interschimbare, aceasta se efectueaza si se pune flagul notSorted pe true*/
            inregistrari[i].parentNode.insertBefore(inregistrari[i + 1], inregistrari[i]);
            notSorted = true;
            nrInterschimbari++;
        } else {
            /*Daca nu s-a facut nicio interschimbare si directia e ascendenta se seteaza pe "descendenta" si se executa while-ul din nou*/
            if (nrInterschimbari == 0 && dir == "ascendenta") {
                dir = "descendenta";
                notSorted = true;
            }
        }
    }
}
