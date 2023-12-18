import { IConfigurationState } from "./IConfigurationState"
import { IEnhancedPrice } from "./IEnhancedPrice"
import { ISearchStyleBodyType } from "./ISearchStyleBodyType"
import { ISearchStyleModel } from "./ISearchStyleModel"
import { PriceState } from "./Enumerations"
import { MatTableDataSource } from "@angular/material/table"

export interface IStyles{
    model: ISearchStyleModel | MatTableDataSource<ISearchStyleModel>,
    styleId: number,
    styleName:string,
    styleNameWithoutTrim: string,
    trimName:number,
    manufacturerModelCode: string,
    //styleGroupStyleIds: number[],
    styleGroupBase: boolean,
    baseMsrp: number,
    baseInvoice: number,
    startingAtInvoice: number,
    startingAtInvoiceSpecified: boolean,
    startingAtMsrpSpecified: boolean,
    StartingAtMsrpField: number,
    destination: number,
    trueBasePrice: boolean,
    passengerDoors: number,
    marketClassId: number,
    marketClassName: string,
    allocationGroup: string[],
    stockPhotoUrl: string,
    consumerFriendlyModelName: string,
    consumerFriendlyStyleName: string,
    consumerFriendlyDrivetrain: string,
    consumerFriendlyBodyType: string,
    marketingCopy: string,
    enhancedBasePrices: IEnhancedPrice[] | null,
    priceState: string,
    bodyTypes: ISearchStyleBodyType[],
    configurationStateField: IConfigurationState
}

