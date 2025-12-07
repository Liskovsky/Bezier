# ✍️ Implementace Kubické Bézierovy Křivky

[cite_start]Tento projekt je realizací korespondenčního úkolu zaměřeného na vykreslování **splajnu** založeného na **kubické Bézierově křivce** v prostředí aplikace Windows Forms (Visual Studio/C#)[cite: 8]. [cite_start]Projekt demonstruje dva přístupy k vykreslení křivky: pomocí integrovaných grafických nástrojů Visual Studia a pomocí vlastní implementace generování bodů[cite: 52, 94].

---

## 🎯 Zadání úkolu

[cite_start]Cílem bylo realizovat splajn [cite: 8] (emulace nástroje z MS Word)[cite_start], který by pro posloupnost kontrolních bodů $P_1, P_2, \dots, P_n$ [cite: 9] [cite_start]generoval kubické Bézierovy křivky [cite: 13] [cite_start]na čtveřicích bodů $(P_i, R_i, L_{i+1}, P_{i+1})$[cite: 13]. [cite_start]Křivka měla být generována diskretizací a vykreslena jako lineárně lomená čára[cite: 15].

> [cite_start]**Poznámka:** Postup byl realizován dle vlastních zkušeností a informací z internetu, jelikož doporučený text s pseudokódem nebyl na Moodle nalezen[cite: 19].

---

## 💻 Implementace a Klíčové Metody

[cite_start]Aplikace využívá třídu **`Form1`** pro hlavní okno a grafické operace[cite: 35]. [cite_start]Kreslení probíhá na komponentě `PictureBox`[cite: 72, 75].

### Inicializace

| Proměnná | Typ | Popis |
| :--- | :--- | :--- |
| `controlPoints` | `List<PointF>` | [cite_start]Seznam pro uchovávání kontrolních bodů[cite: 38]. |
| `splinePoints` | `List<PointF>` | [cite_start]Seznam pro uchovávání generovaných bodů křivky[cite: 41]. |
| `stepSize` | `float` (`0.01F`) | [cite_start]Velikost kroku pro diskretizaci křivky[cite: 43]. |
| `p0, p1, p2, p3` | `System.Drawing.Point` | [cite_start]Aktuální 4 kontrolní body pro kubickou Bézierovu křivku[cite: 49]. |

### Funkce pro generování bodů

[cite_start]Metoda **`GenerujBezierBody(P0, P1, P2, P3, t)`** implementuje standardní polynomický vzorec pro výpočet bodu na kubické Bézierově křivce pro daný parametr $t$ (kde $0 \le t \le 1$) a čtyři kontrolní body[cite: 141, 142]:

$$
P(t) = (1-t)^3 P_0 + 3(1-t)^2 t P_1 + 3(1-t) t^2 P_2 + t^3 P_3
$$


### Metody vykreslování

[cite_start]Vykreslování je spouštěno událostmi kliknutí na tlačítka (Event Handler)[cite: 157]:

#### 1. `BezierClassic()` (Tlačítko: "Bézierova křivka VS")
[cite_start]Vykresluje křivku pomocí integrované metody **`g.DrawBezier()`**[cite: 61, 179].
* [cite_start]Generuje náhodné kontrolní body `p0` až `p3`[cite: 55].
* [cite_start]Křivka je vykreslena červeným perem, kontrolní body modrými obdélníky[cite: 86, 89].

#### 2. `VytvorKrivkuBezier()` (Tlačítko: "Bezier dle zadání")
[cite_start]Vykresluje křivku bez použití integrované funkce `g.DrawBezier()`[cite: 94].
* [cite_start]Generuje náhodné kontrolní body[cite: 102].
* [cite_start]Křivka je diskretizována na 101 bodů voláním `GenerujBezierBody` pro $t \in [0, 1]$[cite: 111, 113, 136].
* [cite_start]Vykreslení probíhá pomocí metody **`g.DrawLines(red, curvePoints)`** (lomená čára)[cite: 115, 137].

#### 3. `SpojBody()` (Tlačítko: "Lineární úsečka bodů")
[cite_start]Načte existující obrázek s křivkou a na něj vykreslí modré úsečky spojující kontrolní body `p0-p1`, `p1-p2` a `p2-p3`[cite: 189, 193]. [cite_start]Toto vizualizuje řídicí polygon křivky[cite: 225]. [cite_start]Tlačítko se stane viditelným až po vykreslení jedné z křivek[cite: 173, 175].

---

## 🖼️ Ukázky Rozhraní

Aplikace umožňuje přímé porovnání obou implementací a vizualizaci řídicího polygonu.

* [cite_start]**Úvodní obrazovka** [cite: 237]
    * 
* [cite_start]**Vykreslení s integrovaným prvkem** (včetně zobrazení řídicího polygonu) [cite: 247, 263]
    * 
* [cite_start]**Vykreslení vlastním postupem** (včetně zobrazení řídicího polygonu) [cite: 270, 279]
    *
