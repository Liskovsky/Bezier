# Implementace Kubické Bézierovy Křivky

Tento projekt v jazyce C# (Windows Forms/Visual Studio) realizuje úkol zaměřený na vykreslování **splajnu** založeného na **kubické Bézierově křivce**. Projekt demonstruje dva přístupy: využití integrovaných grafických nástrojů Visual Studia a použití vlastní implementace generování bodů.

---

## Zadání a Cíl

Cílem bylo implementovat splajn (emulace nástroje z MS Word). Požadovaný postup zahrnoval:
1. Zvolení posloupnosti bodů $P_1, P_2, \dots, P_n$ ($n \ge 3$).
2. Rozšíření o body $P_0=P_1$ a $P_{n+1}=P_n$.
3. Pro každý bod $P_i$ generování dvojice kontrolních bodů $L_i$ a $R_i$.
4. Generování kubické Bézierovy křivky na každé čtveřici bodů $(P_i, R_i, L_{i+1}, P_{i+1})$.
5. Vykreslení diskretizované křivky jako lineárně lomené čáry.

> **Poznámka:** Implementace se řídila vlastními zkušenostmi a informacemi z internetu, protože doporučený pseudokód nebyl k dispozici.

---

## Struktura a Klíčové Metody

Aplikace využívá třídu **`Form1`** pro hlavní okno a grafické operace prováděné na komponentě `PictureBox`.

### 1. Inicializační proměnné

| Proměnná | Typ | Popis |
| :--- | :--- | :--- |
| `controlPoints` | `List<PointF>` | Seznam kontrolních bodů křivky. |
| `splinePoints` | `List<PointF>` | Seznam vygenerovaných bodů na křivce. |
| `stepSize` | `float` (`0.01F`) | Velikost kroku diskretizace. |
| `p0, p1, p2, p3` | `System.Drawing.Point` | Proměnné pro definování 4 kontrolních bodů kubické křivky. |

### 2. Generování bodů na křivce

Klíčová funkce **`GenerujBezierBody(P0, P1, P2, P3, t)`** implementuje standardní polynomický vzorec pro výpočet bodu na kubické Bézierově křivce:

$$
P(t) = (1-t)^3 P_0 + 3(1-t)^2 t P_1 + 3(1-t) t^2 P_2 + t^3 P_3
$$


### 3. Vykreslovací Metody

Aplikace poskytuje dvě metody pro vykreslení, spouštěné tlačítky, a jednu pro vizualizaci řídicího polygonu:

#### A. Vykreslení integrovaným prvkem (`BezierClassic()`)
Vykresluje křivku pomocí vestavěné metody **`g.DrawBezier()`**.

#### B. Vykreslení vlastním postupem (`VytvorKrivkuBezier()`)
Vykresluje křivku bez použití integrované funkce. Využívá vlastní funkci `GenerujBezierBody` k diskretizaci na 101 bodů. Vykreslení probíhá pomocí **`g.DrawLines()`** (lomená čára).

#### C. Spojení Bodů (`SpojBody()`)
Načte existující obrázek a vykreslí modré úsečky (`g.DrawLine`) spojující kontrolní body `p0-p1`, `p1-p2` a `p2-p3`, čímž vizualizuje řídicí polygon křivky.

---

## Ukázky Rozhraní

Aplikace umožňuje uživateli porovnat obě implementace a zobrazit řídicí polygon.

* **Vykreslení VS Doplňky s polygonem**
    * 
* **Vykreslení dle Zadání s polygonem**
    *
