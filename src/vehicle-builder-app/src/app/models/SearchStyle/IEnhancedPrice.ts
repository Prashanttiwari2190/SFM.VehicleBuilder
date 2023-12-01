import { IEnhancedPriceLevel } from "./IEnhancedPriceLevel";
import { PriceState } from "./Enumerations";

export interface IEnhancedPrice{
    price: number,
    masked: boolean,
    priceState: string,
    pricelevel: IEnhancedPriceLevel,
}

