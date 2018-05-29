export class Domanda {
    constructor(
        public fiscalCode: string, 
        public firstName: string,
        public lastName: string,
        public birthDate: string, 
        public email: string,
        public businessUnits: string[],
        public workingDays: number,
        public drivingLicense: string,
        public pin: string
    ) {}
    
}


