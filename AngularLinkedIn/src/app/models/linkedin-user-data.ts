export interface Identifier {
  identifier: string;
  index: number;
  mediaType: string;
  file: string;
  identifierType: string;
  identifierExpiresInSeconds: number;
}

export interface IElement {
  identifiers: Identifier[];
}

export interface IDisplayImage {
  elements: IElement[];
}

export interface IProfilePicture {
  displayImage: IDisplayImage;
}

export interface ILinkedInUserData {
  id: string;
  localizedFirstName: string;
  localizedLastName: string;
  profilePicture: IProfilePicture;
}

