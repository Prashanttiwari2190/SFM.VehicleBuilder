import { IConditionProperty } from "./IConditionProperty";
import { IConfigurationConstraint } from "./IConfigurationConstraint";
import { IUserDefinedTechSpecs } from "./IUserDefinedTechSpecs";
import { OrderAvailability } from "./Enumerations";

export interface IConfigurationState{
    dataVersionField: Date | null,
    styleIdField: number,
    fullyConfiguredField: boolean,
    orderAvailabilityField: string,
    specialEquipmentEnabledField: boolean,
    optionOrderLogicDisabledField: boolean,
    initialPricingEnabledField: boolean,
    chromeOptionCodeToggleStreamField: string[] | null,
    selectedChromeOptionCodesField: string[] | null,
    conditionPropertiesField: IConditionProperty[],
    constraintField:  IConfigurationConstraint,
    userDefinedTechSpecsField: IUserDefinedTechSpecs | null,
    serializedValueField: string,
    }
    
    